using System;
using System.Collections.Generic;

namespace Enumerable
{
    static class Enumerable
    {
        public static bool All<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(predicate, nameof(predicate));
            foreach (var elem in source)
            {
                if (!predicate(elem))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool Any<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(predicate, nameof(predicate));
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    return true;
                }
            }

            return false;
        }

        public static TSource First<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(predicate, nameof(predicate));
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    return elem;
                }
            }

            throw new InvalidOperationException("None of the elements meet the condition.");
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(selector, nameof(selector));
            foreach (var elem in source)
            {
                yield return selector(elem);
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(selector, nameof(selector));
            foreach (var elem in source)
            {
                foreach (var item in selector(elem))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TSource> Where<TSource>(
            this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(predicate, nameof(predicate));
            foreach (var elem in source)
            {
                if (predicate(elem))
                {
                    yield return elem;
                }
            }
        }

        public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
           this IEnumerable<TSource> source,
           Func<TSource, TKey> keySelector,
           Func<TSource, TElement> elementSelector)
        {
            Dictionary<TKey, TElement> dict = new Dictionary<TKey, TElement>();
            foreach (var elem in source)
            {
                dict.Add(keySelector(elem), elementSelector(elem));
            }

            return dict;
        }

        private static void CheckArgumentNotNull<T>(T argument, string argName)
        {
            if (argument != null)
            {
                return;
            }

            throw new ArgumentNullException(argName);
        }
    }
}
