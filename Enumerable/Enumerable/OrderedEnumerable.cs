using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Enumerable
{
    class OrderedEnumerable<TSource> : IOrderedEnumerable<TSource>
    {
        private readonly IComparer<TSource> comparer;
        private IEnumerable<TSource> source;

        public OrderedEnumerable(IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            this.source = source;
            this.comparer = comparer;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(
                    Func<TSource, TKey> keySelector,
                    IComparer<TKey> comparer,
                    bool descending)
        {
            IComparer<TSource> secondComparer =
                new ElementComparer<TSource, TKey>(keySelector, comparer);
            return new OrderedEnumerable<TSource>(
                source, new CompoundComparer<TSource>(this.comparer, secondComparer));
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            InsertionSort(ref source);
            foreach (var elem in source)
            {
                yield return elem;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void InsertionSort(ref IEnumerable<TSource> source)
        {
            TSource[] array = source.ToArray();
            for (int i = 1; i < array.Length; i++)
            {
                var key = array[i];
                int j;
                for (j = i - 1;
                     j >= 0 && comparer.Compare(array[j], key) > 0;
                     j--)
                {
                    array[j + 1] = array[j];
                }

                array[j + 1] = key;
            }

            source = array;
        }
    }
}
