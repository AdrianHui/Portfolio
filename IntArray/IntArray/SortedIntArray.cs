using System;

namespace IntegerArray
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override int this[int index]
        {
            get => data[index];
            set
            {
                if (!CanBeSet(value, index))
                {
                    return;
                }

                data[index] = value;
            }
        }

        public override void Add(int element)
        {
            base.Add(element);
            Sort();
        }

        public override void Insert(int index, int element)
        {
            if (element > data[index])
            {
                return;
            }

            base.Insert(index, element);
        }

        private void Sort()
        {
            for (int i = Count - 1; i > 0; i--)
            {
                if (data[i - 1] > data[i])
                {
                    SwapAtIndex(i - 1, i);
                }
            }
        }

        private void SwapAtIndex(int firstElementIndex, int secondElementIndex)
        {
            var temp = data[firstElementIndex];
            data[firstElementIndex] = data[secondElementIndex];
            data[secondElementIndex] = temp;
        }

        private bool CanBeSet(int element, int indexToBeSetOn)
        {
            return indexToBeSetOn == 0
                ? element <= data[indexToBeSetOn + 1]
                : element >= data[indexToBeSetOn - 1] && element <= data[indexToBeSetOn + 1];
        }
    }
}
