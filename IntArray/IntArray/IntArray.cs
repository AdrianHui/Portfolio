using System;

namespace IntegerArray
{
    class IntArray
    {
        public int CountElements;
        public int[] Data;

        public IntArray()
        {
            this.Data = new int[4];
            this.CountElements = 0;
        }

        public void Add(int element)
        {
            if (CountElements >= Data.Length)
            {
                Array.Resize(ref Data, Data.Length * 2);
            }

            Data[CountElements] = element;
            CountElements++;
        }

        public int Count()
        {
            return CountElements;
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
            for (int i = 0; i < CountElements; i++)
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
            for (int i = 0; i < CountElements; i++)
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
            for (int i = CountElements + 1; i > index; i--)
            {
                Data[i] = Data[i - 1];
            }

            Data[index] = element;
            CountElements++;
        }

        public void Clear()
        {
            Data = new int[4];
            CountElements = 0;
        }

        public void Remove(int element)
        {
            if (IndexOf(element) == Data.Length - 1)
            {
                Data[IndexOf(element)] = 0;
                CountElements--;
                return;
            }

            for (int i = IndexOf(element); i < CountElements; i++)
            {
                Data[i] = Data[i + 1];
            }

            CountElements--;
        }

        public void RemoveAt(int index)
        {
            if (index == Data.Length - 1)
            {
                Data[index] = 0;
                CountElements--;
                return;
            }

            for (int i = index; i < CountElements; i++)
            {
                Data[i] = Data[i + 1];
            }

            CountElements--;
        }
    }
}
