using System;

namespace IntegerArray
{
    class IntArray
    {
        protected int[] data;

        public IntArray()
        {
            data = new int[4];
        }

        public int Count { get; private set; }

        public virtual int this[int index] { get => data[index]; set => data[index] = value; }

        public virtual void Add(int element)
        {
            ExpandCheck();
            data[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            return GetIndex(element);
        }

        public virtual void Insert(int index, int element)
        {
            ShiftRight(index);
            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
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
                data[i] = i == Count - 1 || i == data.Length - 1
                        ? 0 : data[i + 1];
            }
        }

        private int GetIndex(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (data[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
