using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Enumerable
{
    class CompoundComparer<T> : IComparer<T>
    {
        private readonly IComparer<T> first;
        private readonly IComparer<T> second;

        public CompoundComparer(IComparer<T> first, IComparer<T> second)
        {
            this.first = first;
            this.second = second;
        }

        public int Compare([AllowNull] T x, [AllowNull] T y)
        {
            int firstComparison = first.Compare(x, y);
            return firstComparison == 0 ? second.Compare(x, y) : firstComparison;
        }
    }
}
