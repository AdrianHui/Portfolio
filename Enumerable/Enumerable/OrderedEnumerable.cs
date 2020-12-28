using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Enumerable
{
    class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
    {
        private readonly IEnumerable<TSource> source;

        public OrderedEnumerable(IEnumerable<TSource> source)
        {
            this.source = source;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(
                    Func<TSource, TKey> keySelector,
                    IComparer<TKey> comparer,
                    bool descending)
        {
            return new OrderedEnumerable<TSource>(InsertionSort(source, keySelector, comparer));
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            foreach (var elem in source)
            {
                yield return elem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<TSource> InsertionSort<TKey>(
                    IEnumerable<TSource> source,
                    Func<TSource, TKey> keySelector,
                    IComparer<TKey> comparer)
        {
            TSource[] array = source.ToArray();
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                int j;
                for (j = i - 1;
                     j >= 0 && comparer.Compare(keySelector(array[j]), keySelector(key)) > 0;
                     j--)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = key;
            }

            return array;
        }
    }
}
