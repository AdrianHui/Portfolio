using System;
using System.Collections.Generic;
using Linq;
using Xunit;

namespace Linq.Facts
{
    public class LinqMethodsFacts
    {
        [Fact]
        public void ConsonantAndVowelCounterShouldReturnTheNumberOfConsonantsAndVowelsInGivenString()
        {
            var linq = new LinqMethods();
            var (vowels, consonants) = linq.ConsonantAndVowelCounter("test");
            Assert.True(vowels == 1 && consonants == 3);
        }

        [Fact]
        public void FirstUniqueCharacterShouldReturnFirstUniqueCharacterFromGivenString()
        {
            var linq = new LinqMethods();
            char result = linq.FirstUniqueCharacter("teest");
            Assert.Equal('s', result);
        }

        [Fact]
        public void ConvertToIntShouldConvertNumberAsStringToInt()
        {
            var linq = new LinqMethods();
            int result = linq.ConvertToInt("12345678");
            Assert.Equal(12345678, result);
        }

        [Fact]
        public void MostOccurencesShouldReturnTheCharacterWithMostOccurencesInGivenString()
        {
            var linq = new LinqMethods();
            var result = linq.MostOccurences("test");
            Assert.Equal('t', result);
        }

        [Fact]
        public void GetPalindromesShouldGenerateAllPossiblePalindromesFromGivenString()
        {
            var linq = new LinqMethods();
            var result = linq.GetPalindromes("aabaac");
            Assert.Equal(new[] { "a", "aa", "aabaa", "a", "aba", "b", "a", "aa", "a", "c" }, result);
        }
    }
}
