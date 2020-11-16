using System;

namespace IntegerArray
{
    class IntArray
    {
        public int CountValues;
        public int[] Data;

        public IntArray()
        {
            this.Data = new int[4];
            this.CountValues = 0;
        }

        public void Add(int element)
        {
            if (CountValues >= Data.Length)
            {
                Array.Resize(ref Data, Data.Length * 2);
            }

            Data[CountValues] = element;
            CountValues++;
        }

        public int Count()
        {
            return CountValues;
        }

        public int Element(int index)
        {
            return Data[index];
        }

        public void SetElement(int index, int element)
        {
            Data[index] = element;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < CountValues; i++)
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
            for (int i = 0; i < CountValues; i++)
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
            for (int i = CountValues + 1; i > index; i--)
            {
                Data[i] = Data[i - 1];
            }

            Data[index] = element;
            CountValues++;
        }

        public void Clear()
        {
            Data = new int[4];
            CountValues = 0;
        }

        public void Remove(int element)
        {
            if (IndexOf(element) == Data.Length - 1)
            {
                Data[IndexOf(element)] = 0;
                CountValues--;
                return;
            }

            for (int i = IndexOf(element); i < CountValues; i++)
            {
                Data[i] = Data[i + 1];
            }

            CountValues--;
        }

        public void RemoveAt(int index)
        {
            if (index == Data.Length - 1)
            {
                Data[index] = 0;
                CountValues--;
                return;
            }

            for (int i = index; i < CountValues; i++)
            {
                Data[i] = Data[i + 1];
            }

            CountValues--;
        }
    }
}
