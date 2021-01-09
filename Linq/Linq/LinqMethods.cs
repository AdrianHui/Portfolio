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
            return text.GroupBy(x => x, y => y, (key, value) => (key, value.Count()))
                .OrderBy(x => x.Item2).First().key;
        }

        public int ConvertToInt(string text)
        {
            return text.Select(x => (int)char.GetNumericValue(x)).Aggregate((x, y) => x * 10 + y);
        }

        public char MostOccurences(string text)
        {
            return text.GroupBy(x => x, y => y, (key, value) => (key, value.Count()))
                .OrderByDescending(x => x.Item2).First().key;
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
            return substrings.Where(x => !x.Where((t, i) => t != x[x.Length - 1 - i]).Any());
        }
    }
}
