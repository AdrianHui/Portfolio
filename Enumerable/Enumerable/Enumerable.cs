using System;
using System.Collections.Generic;
using System.Linq;

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
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(keySelector, nameof(keySelector));
            CheckArgumentNotNull(elementSelector, nameof(elementSelector));
            Dictionary<TKey, TElement> dict = new Dictionary<TKey, TElement>();
            foreach (var elem in source)
            {
                dict.Add(keySelector(elem), elementSelector(elem));
            }

            return dict;
        }

        public static IEnumerable<TResult> Zip<TFirst, TSecond, TResult>(
                    this IEnumerable<TFirst> first,
                    IEnumerable<TSecond> second,
                    Func<TFirst, TSecond, TResult> resultSelector)
        {
            CheckArgumentNotNull(first, nameof(first));
            CheckArgumentNotNull(second, nameof(second));
            CheckArgumentNotNull(resultSelector, nameof(resultSelector));
            var firstEnum = first.GetEnumerator();
            var secondEnum = second.GetEnumerator();
            while (firstEnum.MoveNext() && secondEnum.MoveNext())
            {
                yield return resultSelector(firstEnum.Current, secondEnum.Current);
            }
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(
                    this IEnumerable<TSource> source,
                    TAccumulate seed,
                    Func<TAccumulate, TSource, TAccumulate> func)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(func, nameof(func));
            foreach (var elem in source)
            {
                seed = func(seed, elem);
            }

            return seed;
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
                    this IEnumerable<TOuter> outer,
                    IEnumerable<TInner> inner,
                    Func<TOuter, TKey> outerKeySelector,
                    Func<TInner, TKey> innerKeySelector,
                    Func<TOuter, TInner, TResult> resultSelector)
        {
            CheckArgumentNotNull(outer, nameof(outer));
            CheckArgumentNotNull(inner, nameof(inner));
            CheckArgumentNotNull(outerKeySelector, nameof(outerKeySelector));
            CheckArgumentNotNull(innerKeySelector, nameof(innerKeySelector));
            CheckArgumentNotNull(resultSelector, nameof(resultSelector));
            foreach (var elem in outer)
            {
                foreach (var item in inner)
                {
                    if (outerKeySelector(elem).Equals(innerKeySelector(item)))
                    {
                        yield return resultSelector(elem, item);
                    }
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(
                    this IEnumerable<TSource> source,
                    IEqualityComparer<TSource> comparer)
        {
            CheckArgumentNotNull(source, nameof(source));
            foreach (var elem in new HashSet<TSource>(source, comparer))
            {
                yield return elem;
            }
        }

        public static IEnumerable<TSource> Union<TSource>(
                    this IEnumerable<TSource> first,
                    IEnumerable<TSource> second,
                    IEqualityComparer<TSource> comparer)
        {
            CheckArgumentNotNull(first, nameof(first));
            CheckArgumentNotNull(second, nameof(second));
            HashSet<TSource> items = new HashSet<TSource>(first, comparer);
            items.UnionWith(second);
            foreach (var elem in items)
            {
                yield return elem;
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(
                    this IEnumerable<TSource> first,
                    IEnumerable<TSource> second,
                    IEqualityComparer<TSource> comparer)
        {
            CheckArgumentNotNull(first, nameof(first));
            CheckArgumentNotNull(second, nameof(second));
            HashSet<TSource> items = new HashSet<TSource>(first, comparer);
            items.IntersectWith(second);
            foreach (var elem in items)
            {
                yield return elem;
            }
        }

        public static IEnumerable<TSource> Except<TSource>(
                    this IEnumerable<TSource> first,
                    IEnumerable<TSource> second,
                    IEqualityComparer<TSource> comparer)
        {
            CheckArgumentNotNull(first, nameof(first));
            CheckArgumentNotNull(second, nameof(second));
            HashSet<TSource> items = new HashSet<TSource>(first, comparer);
            items.ExceptWith(second);
            foreach (var elem in items)
            {
                yield return elem;
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
                    this IEnumerable<TSource> source,
                    Func<TSource, TKey> keySelector,
                    Func<TSource, TElement> elementSelector,
                    Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
                    IEqualityComparer<TKey> comparer)
        {
            CheckArgumentNotNull(source, nameof(source));
            CheckArgumentNotNull(keySelector, nameof(keySelector));
            CheckArgumentNotNull(elementSelector, nameof(elementSelector));
            Dictionary<TKey, List<TElement>> items = new Dictionary<TKey, List<TElement>>(comparer);
            foreach (var elem in source)
            {
                var key = keySelector(elem);
                if (items.ContainsKey(key))
                {
                    items[key].Add(elementSelector(elem));
                }
                else
                {
                    items.Add(key, new List<TElement>() { elementSelector(elem) });
                }
            }

            foreach (var item in items)
            {
                yield return resultSelector(item.Key, item.Value);
            }
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
