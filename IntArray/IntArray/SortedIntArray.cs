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
            if (!CanBeInserted(element, index))
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

        private bool CanBeSet(int element, int index)
        {
            return IsInAscendingOrder(element, index, index - 1, index + 1);
        }

        private bool CanBeInserted(int element, int index)
        {
            return index == Count
                ? element >= data[index - 1]
                : IsInAscendingOrder(element, index, index - 1, index);
        }

        private bool IsInAscendingOrder(int element, int currentIndex, int precedingElementIndex, int followingElementIndex)
        {
            return currentIndex == 0
                ? element <= data[followingElementIndex]
                : element >= data[precedingElementIndex] && element <= data[followingElementIndex];
        }
    }
}
