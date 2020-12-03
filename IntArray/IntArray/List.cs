using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegerArray
{
    class List<T> : IList<T>
    {
        protected T[] data;

        public List()
        {
            data = new T[4];
        }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public virtual T this[int index]
        {
            get
            {
                ValidIndexCheck(index, 0, Count - 1);
                return data[index];
            }

            set
            {
                ValidIndexCheck(index, 0, Count - 1);
                data[index] = value;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
            ValidIndexCheck(index, 0, Count);
            ShiftRight(index);
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(T element)
        {
            int currentIndex = IndexOf(element);
            if (currentIndex == -1)
            {
                return false;
            }

            RemoveAt(currentIndex);
            return true;
        }

        public void RemoveAt(int index)
        {
            ValidIndexCheck(index, 0, Count - 1);
            ShiftLeft(index);
            Count--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "Cannot be null.");
            }

            ValidIndexCheck(arrayIndex, 0, array.Length - 1);
            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("There is not enough space in destination array.");
            }

            for (int i = 0; i < Count; i++)
            {
                array[arrayIndex + i] = data[i];
            }
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
            ExpandCheck();
            for (int i = Count; i > stopIndex; i--)
            {
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

        private void ValidIndexCheck(int index, int startIndex, int endIndex)
        {
            if (index >= startIndex && index <= endIndex)
            {
                return;
            }

            throw new ArgumentOutOfRangeException("index", "Index was outside the bounds of the colletion.");
        }
    }
}