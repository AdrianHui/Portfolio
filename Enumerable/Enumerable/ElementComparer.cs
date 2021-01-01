using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Enumerable
{
    class SourceComparer<TSource, TKey> : IComparer<TSource>
    {
        private readonly Func<TSource, TKey> keySelector;
        private readonly IComparer<TKey> comparer;

        public SourceComparer(Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            this.keySelector = keySelector;
            this.comparer = comparer;
        }

        public int Compare([AllowNull] TSource x, [AllowNull] TSource y)
        {
            TKey first = keySelector(x);
            TKey second = keySelector(y);
            return comparer.Compare(first, second);
        }
    }
}
