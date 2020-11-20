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
            Sort();
        }

        private void Sort()
        {
            for (int i = 1; i < Count; i++)
            {
                ShiftLeft(i);
            }
        }

        private void ShiftLeft(int startingIndex)
        {
            for (int j = startingIndex; j > 0; j--)
            {
                if (data[j - 1] > data[j])
                {
                    SwapAtIndex(j, j - 1);
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
