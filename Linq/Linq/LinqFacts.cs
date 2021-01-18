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

        [Fact]
        public void ProductsThatHaveAtLeastAFeatureInCommonShouldReturnAllProductsThatHaveAtLeastAFeatureFromFeaturesList()
        {
            var linq = new LinqMethods();
            Product prod1 = new Product();
            Product prod2 = new Product();
            Product prod3 = new Product();
            Feature feat1 = new Feature();
            Feature feat2 = new Feature();
            Feature feat3 = new Feature();
            feat1.Id = 1;
            feat2.Id = 5;
            feat3.Id = 10;
            prod1.Features = new[] { feat1, feat3 };
            prod2.Features = new[] { feat2, feat3 };
            prod3.Features = new[] { feat1, feat2 };
            var products = new[] { prod1, prod2, prod3 };
            var features = new[] { feat2 };
            var result = linq.ProductsThatHaveAtLeastAFeatureInCommon(products, features);
            Assert.Equal(new[] { prod2, prod3 }, result);
        }
    }
}
