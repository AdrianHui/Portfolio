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
                if (!IsCorrectPosition(value, index))
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
            if (!IsCorrectPosition(element, index))
            {
                return;
            }

            base.Insert(index, element);
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
            int valueToInsert = data[startingIndex];
            int j = startingIndex - 1;
            while (j >= 0 && data[j] > valueToInsert)
            {
                SwapAtIndex(j + 1, j);
                j--;
            }

            data[j + 1] = valueToInsert;
        }

        private void SwapAtIndex(int firstElementIndex, int secondElementIndex)
        {
            var temp = data[firstElementIndex];
            data[firstElementIndex] = data[secondElementIndex];
            data[secondElementIndex] = temp;
        }

        private bool IsCorrectPosition(int element, int indexToBeSetOn)
        {
            return indexToBeSetOn == 0
                ? data[indexToBeSetOn + 1] < element
                : element >= data[indexToBeSetOn - 1] && element <= data[indexToBeSetOn + 1];
        }
    }
}
