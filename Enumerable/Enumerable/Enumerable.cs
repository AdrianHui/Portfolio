using System;
using System.Collections.Generic;

namespace Enumerable
{
    static class Enumerable
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            SourceValidCheck(source);
            PredicateValidCheck(predicate);
            foreach (var elem in source)
            {
                if (!predicate(elem))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            SourceValidCheck(source);
            PredicateValidCheck(predicate);
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    return true;
                }
            }

            return false;
        }

        private static void SourceValidCheck<TSource>(IEnumerable<TSource> source)
        {
            if (source != null)
            {
                return;
            }

            throw new ArgumentNullException("source");
        }

        private static void PredicateValidCheck<TSource>(Func<TSource, bool> predicate)
        {
            if (predicate != null)
            {
                return;
            }

            throw new ArgumentNullException("predicate");
        }
    }
}
