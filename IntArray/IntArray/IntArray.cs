using System;

namespace IntegerArray
{
    class IntArray
    {
        protected int[] data;

        public IntArray()
        {
            data = new int[4];
            Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index] { get => data[index]; set => data[index] = value; }

        public void Add(int element)
        {
            if (Count >= data.Length)
            {
                Array.Resize(ref data, data.Length * 2);
            }

            data[Count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            return IndexOf(element) >= 0;
        }

        public int IndexOf(int element)
        {
            return Array.IndexOf(data, element) < Count ? Array.IndexOf(data, element) : -1;
        }

        public void Insert(int index, int element)
        {
            for (int i = Count + 1; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = element;
            Count++;
        }

        public void Clear()
        {
            data = new int[4];
            Count = 0;
        }

        public void Remove(int element)
        {
            RemoveAt(IndexOf(element));
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                data[i] = index == data.Length - 1 ? 0 : data[i + 1];
            }

            Count--;
        }
    }
}
