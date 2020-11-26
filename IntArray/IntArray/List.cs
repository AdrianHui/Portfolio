using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    class List<T> : IEnumerable<T>
    {
        private T[] data;

        public List()
        {
            data = new T[4];
        }

        public int Count { get; private set; }

        public virtual T this[int index] { get => data[index]; set => data[index] = value; }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public virtual void Add(T element)
        {
            ExpandCheck();
            data[Count] = element;
            Count++;
        }

        public bool Contains(T element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(T element)
        {
            return GetIndex(element);
        }

        public virtual void Insert(int index, T element)
        {
            ShiftRight(index);
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(T element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            ShiftLeft(index);
            Count--;
        }

        private void ExpandCheck()
        {
            if (Count != data.Length)
            {
                return;
            }

            Array.Resize(ref data, data.Length * 2);
        }

        private void ShiftRight(int stopIndex)
        {
            for (int i = Count; i > stopIndex; i--)
            {
                ExpandCheck();
                data[i] = data[i - 1];
            }
        }

        private void ShiftLeft(int startIndex)
        {
            for (int i = startIndex; i < Count; i++)
            {
                data[i] = i == Count - 1 ? default : data[i + 1];
            }
        }

        private int GetIndex(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (data[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}