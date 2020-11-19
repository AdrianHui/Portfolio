using System;
using System.Collections.Generic;
using System.Text;

namespace IntegerArray
{
    class SortedIntArray : IntArray
    {
        public SortedIntArray() : base()
        {
        }

        public override void Add(int element)
        {
            base.Add(element);
            QuickSort(data, 0, Count - 1);
        }

        public override void Insert(int index, int element)
        {
            base.Insert(index, element);
            QuickSort(data, 0, Count - 1);
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return;
            }

            int pivot = Partition(arr, low, high);
            QuickSort(arr, low, pivot - 1);
            QuickSort(arr, pivot + 1, high);
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low;
            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    Switch(i, j);
                    i++;
                }
            }

            Switch(i, high);

            return i;
        }

        private void Switch(int firstElementIndex, int secondElementIndex)
        {
            var temp = data[firstElementIndex];
            data[firstElementIndex] = data[secondElementIndex];
            data[secondElementIndex] = temp;
        }
    }
}
