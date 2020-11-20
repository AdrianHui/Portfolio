using System;

namespace IntegerArray
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Add(int element)
        {
            Insert(element);
        }

        public override void Insert(int element, int index = 0)
        {
            base.Insert(element, index);
            Sort(data);
        }

        private void Sort(int[] array)
        {
            for (int i = 1; i < Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        SwapAtIndex(j, j - 1);
                    }
                }
            }
        }

        private void SwapAtIndex(int firstElementIndex, int secondElementIndex)
        {
            var temp = data[firstElementIndex];
            data[firstElementIndex] = data[secondElementIndex];
            data[secondElementIndex] = temp;
        }
    }
}
