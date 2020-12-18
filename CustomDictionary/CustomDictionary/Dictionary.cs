using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CustomDictionary
{
    internal class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int[] buckets;
        private Element<TKey, TValue>[] elements;
        private int removedElements;

        public Dictionary(int elementsNum)
        {
            elements = new Element<TKey, TValue>[elementsNum];
            buckets = new int[elementsNum];
            removedElements = -1;
            Array.Fill(buckets, -1);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();
                foreach (var elem in this)
                {
                    keys.Add(elem.Key);
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                foreach (var elem in this)
                {
                    values.Add(elem.Value);
                }

                return values;
            }
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public TValue this[TKey key]
        {
            get
            {
                ValidKeyCheck(key);
                CheckIfKeyIsInDict(key);
                return GetValue(key);
            }

            set
            {
                ValidKeyCheck(key);
                CheckIfKeyIsInDict(key);
                SetValue(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            if (ContainsKey(item.Key))
            {
                throw new ArgumentException(
                    "The key you entered already exists in current collection.");
            }

            var bucketIndex = GetBucketIndex(item.Key);
            var firstFreeIndex = GetFirstFreeIndex();
            elements[firstFreeIndex] =
                new Element<TKey, TValue>(item.Key, item.Value, buckets[bucketIndex]);
            buckets[bucketIndex] = firstFreeIndex;
            Count++;
        }

        public bool ContainsKey(TKey key)
        {
            ValidKeyCheck(key);
            return GetPreviousAndCurrentElements(key) != (-1, -1);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool Remove(TKey key)
        {
            ValidKeyCheck(key);
            var (previousElement, currentElement) = GetPreviousAndCurrentElements(key);
            if (previousElement == -1 && currentElement == -1)
            {
                return false;
            }
            else if (previousElement == -1)
            {
                buckets[GetBucketIndex(key)] = elements[currentElement].Next;
            }
            else
            {
                elements[previousElement].Next = elements[currentElement].Next;
            }

            elements[currentElement].Next = removedElements;
            removedElements = currentElement;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            ValidKeyCheck(key);
            if (!ContainsKey(key))
            {
                value = default;
                return false;
            }

            value = GetValue(key);
            return true;
        }

        public void Clear()
        {
            Count = 0;
            elements = new Element<TKey, TValue>[buckets.Length];
            removedElements = -1;
            Array.Fill(buckets, -1);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "Cannot be null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "arrayIndex", "Index was outside the bounds of the array.");
            }
            else if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("There is not enough space in destination array.");
            }

            foreach (var elem in this)
            {
                array[arrayIndex] =
                    new KeyValuePair<TKey, TValue>(elem.Key, elem.Value);
                arrayIndex++;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                for (var current = buckets[i]; current != -1; current = elements[current].Next)
                {
                    yield return new KeyValuePair<TKey, TValue>(
                        elements[current].Key, elements[current].Value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetFirstFreeIndex()
        {
            return removedElements == -1 || Count < removedElements
                ? Count : removedElements;
        }

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % buckets.Length;
        }

        private (int, int) GetPreviousAndCurrentElements(TKey key)
        {
            var bucketFirstElem = buckets[GetBucketIndex(key)];
            if (bucketFirstElem != -1 && elements[bucketFirstElem].Key.Equals(key))
            {
                return (-1, bucketFirstElem);
            }

            for (var previousElem = bucketFirstElem; previousElem != -1; previousElem = elements[previousElem].Next)
            {
                var current = elements[previousElem].Next;
                if (current != -1 && elements[current].Key.Equals(key))
                {
                    return (previousElem, current);
                }
            }

            return (-1, -1);
        }

        private TValue GetValue(TKey key)
        {
            return elements[GetPreviousAndCurrentElements(key).Item2].Value;
        }

        private void SetValue(TKey key, TValue value)
        {
            elements[GetPreviousAndCurrentElements(key).Item2].Value = value;
        }

        private void ValidKeyCheck(TKey key)
        {
            if (key != null)
            {
                return;
            }

            throw new ArgumentNullException("key", "The key you entered is null.");
        }

        private void CheckIfKeyIsInDict(TKey key)
        {
            if (ContainsKey(key))
            {
                return;
            }

            throw new KeyNotFoundException("The key you entered could not be found.");
        }
    }
}
