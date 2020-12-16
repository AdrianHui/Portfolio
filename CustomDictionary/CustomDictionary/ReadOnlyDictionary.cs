using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CustomDictionary
{
    class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> data;

        public ReadOnlyDictionary(IDictionary<TKey, TValue> dict)
        {
            data = dict;
        }

        public ICollection<TKey> Keys { get => data.Keys; }

        public ICollection<TValue> Values { get => data.Values; }

        public int Count { get => data.Count; }

        public bool IsReadOnly { get; } = true;

        public TValue this[TKey key]
        {
            get => data[key];
            set => throw new NotSupportedException("This collection is read-only.");
        }

        public void Add(TKey key, TValue value)
        {
            Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException("This collection is read-only.");
        }

        public bool ContainsKey(TKey key)
        {
            return data.ContainsKey(key);
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return data.Contains(item);
        }

        public bool Remove(TKey key)
        {
            throw new NotSupportedException("This collection is read-only.");
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return data.TryGetValue(key, out value);
        }

        public void Clear()
        {
            throw new NotSupportedException("This collection is read-only.");
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
