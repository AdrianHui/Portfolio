using System;

namespace IntegerArray
{
    class SortedList<T> : List<T>
        where T : IComparable<T>
    {
        public SortedList() : base()
        {
        }

        public override T this[int index]
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

        public override void Add(T element)
        {
            base.Add(element);
            Sort();
        }

        public override void Insert(int index, T element)
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
                if (data[i - 1].CompareTo(data[i]) > 0)
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

        private bool CanBeSet(T element, int index)
        {
            return IsInAscendingOrder(element, index, index - 1, index + 1);
        }

        private bool CanBeInserted(T element, int index)
        {
            return index == Count
                ? element.CompareTo(data[index - 1]) >= 0
                : IsInAscendingOrder(element, index, index - 1, index);
        }

        private bool IsInAscendingOrder(T element, int currentIndex, int precedingElementIndex, int followingElementIndex)
        {
            return currentIndex == 0
                ? element.CompareTo(data[followingElementIndex]) <= 0
                : element.CompareTo(data[precedingElementIndex]) >= 0 && element.CompareTo(data[followingElementIndex]) <= 0;
        }
    }
}
