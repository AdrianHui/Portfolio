using System;
using System.Collections.Generic;

namespace Enumerable
{
    static class Enumerable
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            else if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            foreach (var elem in source)
            {
                if (!predicate(elem))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
