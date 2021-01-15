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

        [Fact]
        public void GetSubShouldReturnAllPossibleArraysThatEvaluateLessOrEqualToGivenNumber()
        {
            var linq = new LinqMethods();
            var result = linq.GetSubArraysThatEvaluateTo(new[] { 1, 2, 3, 4 }, 8);
            Assert.Equal(
                new[]
                {
                new[] { 1, 2 },
                new[] { 1, 2, 3 },
                new[] { 2, 3 },
                new[] { 3, 4 }
                },  result);
        }

        [Fact]
        public void GenerateExpressionsThatHitTargetShouldReturnAllExpressionsOfLengthNThatEvaluateLessOrEqualToK()
        {
            var linq = new LinqMethods();
            var result = linq.GenerateExpressionsThatHitTarget(4, 0);
            Assert.Equal(
                new[]
            {
                new[] { 1, 2, -3, -4 }, new[] { 1, -2, 3, -4 }, new[] { 1, -2, -3, 4 },
                new[] { 1, -2, -3, -4 }, new[] { -1, 2, 3, -4 }, new[] { -1, 2, -3, -4 },
                new[] { -1, -2, 3, -4 }, new[] { -1, -2, -3, 4 }, new[] { -1, -2, -3, -4 }
            }, result);
        }

        [Fact]
        public void GetPythagoreanNumbersShouldReturnAllPythagoreanTriplesInGivenArray()
        {
            var linq = new LinqMethods();
            var result = linq.GetPythagoreanNumbers(new[] { 15, 3, 4, 5, 6, 25, 20 });
            Assert.Equal(
                new[]
                {
                    new[] { 15, 20, 25 }, new[] { 3, 4, 5 },
                    new[] { 4, 3, 5 }, new[] { 20, 15, 25 }
                }, result);
        }
    }
}
