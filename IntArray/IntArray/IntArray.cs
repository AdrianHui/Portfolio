using System;

namespace IntegerArray
{
    class IntArray
    {
        public int[] Data;
        private int count;

        public IntArray()
        {
            this.Data = new int[4];
            this.count = 0;
        }

        public int Count { get => count; private set => count = value; }

        public int this[int index] { get => Data[index]; set => Data[index] = value; }

        public void Add(int element)
        {
            if (count >= Data.Length)
            {
                Array.Resize(ref Data, Data.Length * 2);
            }

            Data[count] = element;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < count; i++)
            {
                if (Data[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(int element)
        {
            for (int i = 0; i < count; i++)
            {
                if (Data[i] == element)
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, int element)
        {
            for (int i = count + 1; i > index; i--)
            {
                Data[i] = Data[i - 1];
            }

            Data[index] = element;
            Count++;
        }

        public void Clear()
        {
            Data = new int[4];
            Count = 0;
        }

        public void Remove(int element)
        {
            for (int i = IndexOf(element); i < count; i++)
            {
                Data[i] = IndexOf(element) == Data.Length - 1
                        ? 0 : Data[i + 1];
            }

            Count--;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < count; i++)
            {
                Data[i] = index == Data.Length - 1
                        ? 0 : Data[i + 1];
            }

            Count--;
        }
    }
}
