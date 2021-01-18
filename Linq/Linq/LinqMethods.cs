using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    public class LinqMethods
    {
        public LinqMethods()
        {
        }

        public (int, int) ConsonantAndVowelCounter(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            const string vowels = "aeiou";
            int vowelsCount = text.Count(character => vowels.Contains(character));
            int consonantsCount = text.Length - vowelsCount;
            return (vowelsCount, consonantsCount);
        }

        public char FirstUniqueCharacter(string text)
        {
            return text.GroupBy(x => x, y => y, (key, value) => (key, count: value.Count()))
                .OrderBy(x => x.count).First().key;
        }

        public int ConvertToInt(string text)
        {
            return text.Select(x => (int)char.GetNumericValue(x)).Aggregate((x, y) => x * 10 + y);
        }

        public char MostOccurences(string text)
        {
            return text.GroupBy(x => x, y => y, (key, value) => (key, value.Count()))
                .Max(x => x.key);
        }

        public IEnumerable<string> GetPalindromes(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            var substrings = Enumerable.Range(0, text.Length)
                .SelectMany(x => Enumerable.Range(1, text.Length - x)
                .Select(y => text.Substring(x, y)));
            return substrings.Where(x => x.SequenceEqual(x.Reverse()));
        }

        public IEnumerable GetSubArraysThatEvaluateTo(int[] numbers, int expectedResult)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("numbers");
            }

            var sub = Enumerable.Range(0, numbers.Length - 1)
                .SelectMany(x => Enumerable.Range(2, numbers.Length - x - 1)
                .Select(y => numbers.Skip(x).Take(y)));
            return sub.Where(y => y.Sum() <= expectedResult);
        }

        public IEnumerable GenerateExpressionsThatHitTarget(int n, int k)
        {
            const string operators = "+-";
            IEnumerable<string> combinations = new[] { "" };
            return Enumerable.Range(1, n).Aggregate(
                    combinations, (seed, v) => seed.SelectMany(
                            y => operators.Select(z => y + z)))
                    .Select(x => x.Select((z, y) => z == '+' ? y + 1 : (y + 1) * -1))
                    .Where(x => x.Sum() <= k);
        }

        public IEnumerable GetPythagoreanNumbers(int[] numbers)
        {
            var triplets = numbers.SelectMany(
                (x, i) => numbers.SelectMany(
                (y, j) => numbers.Select(
                (z, k) => i == j || i == k || j == k ? null : new[] { x, y, z })));
            return triplets.Where(x => x != null && x[0] * x[0] + x[1] * x[1] == x[2] * x[2]);
        }

        public IEnumerable ProductsThatHaveAtLeastAFeatureInCommon(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => x.Features.Intersect(features).Any());
        }

        public IEnumerable ProductsThatHaveAllFeatures(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => x.Features.Intersect(features).Count() == features.Count);
        }

        public IEnumerable ProductsThatDontHaveAnyFeatureInCommon(
            ICollection<Product> products, ICollection<Feature> features)
        {
            return products.Where(x => !x.Features.Intersect(features).Any());
        }
    }
}