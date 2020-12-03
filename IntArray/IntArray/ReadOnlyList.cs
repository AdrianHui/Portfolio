using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    class ReadOnlyList<T> : IList<T>
    {
        private readonly IList<T> data;

        public ReadOnlyList(IList<T> list)
        {
            data = list;
        }

        public int Count { get => data.Count; }

        public bool IsReadOnly { get; } = true;

        public virtual T this[int index]
        {
            get => data[index];
            set
            {
                throw new NotSupportedException("This collection is read only.");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public virtual void Add(T element)
        {
            throw new NotSupportedException("This collection is read only.");
        }

        public bool Contains(T element)
        {
            return data.Contains(element);
        }

        public int IndexOf(T element)
        {
            return data.IndexOf(element);
        }

        public virtual void Insert(int index, T element)
        {
            throw new NotSupportedException("This collection is read only.");
        }

        public void Clear()
        {
            throw new NotSupportedException("This collection is read only.");
        }

        public bool Remove(T element)
        {
            throw new NotSupportedException("This collection is read only.");
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException("This collection is read only.");
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }
    }
}
