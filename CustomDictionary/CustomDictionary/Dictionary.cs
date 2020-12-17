using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CustomDictionary
{
    internal class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly int elementsNum;
        private readonly int[] buckets;
        private Element<TKey, TValue>[] elements;
        private LinkedList<int> removedElements;

        public Dictionary(int elementsNum)
        {
            this.elementsNum = elementsNum;
            elements = new Element<TKey, TValue>[elementsNum];
            removedElements = new LinkedList<int>();
            buckets = new int[elementsNum];
            Array.Fill(buckets, -1);
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && !removedElements.Contains(i))
                    {
                        keys.Add(elements[i].Key);
                    }
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                for (int i = 0; i < elements.Length; i++)
                {
                    if (elements[i] != null && !removedElements.Contains(i))
                    {
                        values.Add(elements[i].Value);
                    }
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
                return GetValue(buckets[GetBucketIndex(key)], key);
            }

            set
            {
                ValidKeyCheck(key);
                CheckIfKeyIsInDict(key);
                SetValue(buckets[GetBucketIndex(key)], key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            ValidKeyCheck(item.Key);
            if (SearchBucket(buckets[GetBucketIndex(item.Key)], item.Key))
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
            var bucket = GetBucketIndex(key);
            if (bucket >= buckets.Length)
            {
                return false;
            }

            return SearchBucket(buckets[bucket], key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool Remove(TKey key)
        {
            ValidKeyCheck(key);
            var bucket = GetBucketIndex(key);
            var firstItem = buckets[bucket];
            if (firstItem != -1 && elements[firstItem].Key.Equals(key))
            {
                removedElements.AddFirst(firstItem);
                buckets[bucket] = elements[firstItem].Next;
                elements[firstItem].Next = -1;
                Count--;
                return true;
            }

            for (var current = firstItem; current != -1; current = elements[current].Next)
            {
                var nextItem = elements[current].Next;
                if (elements[nextItem].Key.Equals(key))
                {
                    removedElements.AddFirst(nextItem);
                    elements[current].Next = elements[nextItem].Next;
                    elements[nextItem].Next = -1;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            ValidKeyCheck(key);
            bool containsKey = this.ContainsKey(key);
            value = containsKey ? GetValue(buckets[GetBucketIndex(key)], key) : default;
            return containsKey;
        }

        public void Clear()
        {
            Count = 0;
            elements = new Element<TKey, TValue>[elementsNum];
            removedElements = new LinkedList<int>();
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

            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] != null)
                {
                    array[arrayIndex] =
                    new KeyValuePair<TKey, TValue>(elements[i].Key, elements[i].Value);
                    arrayIndex++;
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in elements)
            {
                yield return new KeyValuePair<TKey, TValue>(item.Key, item.Value);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetFirstFreeIndex()
        {
            int freeIndexAfterRemove = removedElements.Count == 0 ? -1 : removedElements.First.Value;
            if (freeIndexAfterRemove == -1 || Count < freeIndexAfterRemove)
            {
                return Count;
            }

            removedElements.RemoveFirst();
            return freeIndexAfterRemove;
        }

        private int GetBucketIndex(TKey key)
        {
            var hash = Math.Abs(key.GetHashCode());
            return hash < elementsNum ? hash : hash % elementsNum;
        }

        private bool SearchBucket(int elemIndex, TKey key)
        {
            for (var current = elemIndex; current != -1; current = elements[current].Next)
            {
                if (elements[current].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private TValue GetValue(int elemIndex, TKey key)
        {
            for (var current = elemIndex; current != -1; current = elements[current].Next)
            {
                if (elements[current].Key.Equals(key))
                {
                    return elements[current].Value;
                }
            }

            return default;
        }

        private void SetValue(int elemIndex, TKey key, TValue value)
        {
            for (var current = elemIndex; current != -1; current = elements[current].Next)
            {
                if (elements[current].Key.Equals(key))
                {
                    elements[current].Value = value;
                }
            }
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
            if (SearchBucket(buckets[GetBucketIndex(key)], key))
            {
                return;
            }

            throw new KeyNotFoundException("The key you entered could not be found.");
        }
    }
}
