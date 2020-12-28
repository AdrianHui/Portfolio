using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Enumerable
{
    class CustomComparer<T> : Comparer<T>
        where T : IComparable<T>
    {
        public override int Compare([AllowNull] T x, [AllowNull] T y)
        {
            return x.CompareTo(y);
        }
    }
}
