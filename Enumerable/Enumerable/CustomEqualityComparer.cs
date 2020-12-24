using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Enumerable
{
    class CustomEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals([AllowNull] T x, [AllowNull] T y)
        {
            return x.Equals(y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.GetHashCode();
        }
    }
}
