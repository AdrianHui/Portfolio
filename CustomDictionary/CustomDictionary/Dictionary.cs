using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace CustomDictionary
{
    internal class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public Element<TKey, TValue>[] Items;
        private readonly int[] buckets;
        private readonly int slots;
        private int firstEmptySlot;

        public Dictionary(int slots)
        {
            buckets = Enumerable.Repeat(-1, slots).ToArray();
            Items = new Element<TKey, TValue>[slots];
            this.slots = slots;
        }

        public ICollection<TKey> Keys { get; set; }

        public ICollection<TValue> Values { get; set; }

        public int Count { get; set; }

        public bool IsReadOnly { get; }

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            var hash = item.Key.GetHashCode();
            var bucketIndex = hash < slots ? hash : hash % slots;
            Items[firstEmptySlot] = new Element<TKey, TValue>(item.Key, item.Value, buckets[bucketIndex]);
            buckets[bucketIndex] = firstEmptySlot;
            firstEmptySlot++;
        }

        public bool ContainsKey(TKey key)
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                if (i != -1 && i == key.GetHashCode())
                {
                    return SearchBucket(buckets[i], key);
                }
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private bool SearchBucket(int elemIndex, TKey key)
        {
            for (var current = elemIndex; current != -1; current = Items[current].Next)
            {
                if (Items[current].Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
