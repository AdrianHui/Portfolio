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
            return GetExpressions(n).Where(x => x.Select(y => y[0] == '+'
                                                   ? char.GetNumericValue(y[1])
                                                   : char.GetNumericValue(y[1]) * -1).Sum() <= k)
                                    .Select(x => string.Concat(x.ToArray()));
        }

        private IEnumerable<string> GetOperatorsCombinations(int n)
        {
            const string operators = "+-";
            var combinations = operators.Select(x => x.ToString());
            while (combinations.First().Length < n)
            {
                combinations = combinations.SelectMany(x => operators.Select(z => x + z));
            }

            return combinations;
        }

        private IEnumerable<IEnumerable<string>> GetExpressions(int n)
        {
            return GetOperatorsCombinations(n).Select(x => x.Select(y => y.ToString())
                                              .Zip(Enumerable.Range(1, n).Select(x => x.ToString()))
                                              .Select(x => x.First + x.Second));
        }
    }
}