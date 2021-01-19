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
            Feature feat1 = new Feature() { Id = 1 };
            Feature feat2 = new Feature() { Id = 5 };
            Feature feat3 = new Feature() { Id = 10 };
            Product prod1 = new Product() { Features = new[] { feat1, feat3 } };
            Product prod2 = new Product() { Features = new[] { feat2, feat3 } };
            Product prod3 = new Product() { Features = new[] { feat1, feat2 } };
            var products = new[] { prod1, prod2, prod3 };
            var features = new[] { feat2 };
            var result = linq.ProductsThatHaveAtLeastAFeatureInCommon(products, features);
            Assert.Equal(new[] { prod2, prod3 }, result);
        }

        [Fact]
        public void ProductsThatHaveAllFeaturesShouldReturnAllProductsThatHaveAllFeaturesFromGivenList()
        {
            var linq = new LinqMethods();
            Feature feat1 = new Feature() { Id = 1 };
            Feature feat2 = new Feature() { Id = 5 };
            Feature feat3 = new Feature() { Id = 10 };
            Product prod1 = new Product() { Features = new[] { feat1, feat3 } };
            Product prod2 = new Product() { Features = new[] { feat1, feat2, feat3 } };
            Product prod3 = new Product() { Features = new[] { feat1, feat2 } };
            var products = new[] { prod1, prod2, prod3 };
            var features = new[] { feat1, feat3 };
            var result = linq.ProductsThatHaveAllFeatures(products, features);
            Assert.Equal(new[] { prod1, prod2 }, result);
        }

        [Fact]
        public void ProductsThatDontHaveAntFeatureInCommonShouldReturnAllProductsThatDontHaveAnyOfTheFeaturesFromGivenList()
        {
            var linq = new LinqMethods();
            Feature feat1 = new Feature() { Id = 1 };
            Feature feat2 = new Feature() { Id = 5 };
            Product prod1 = new Product() { Features = new[] { feat1 } };
            Product prod2 = new Product() { Features = new[] { feat2 } };
            var products = new[] { prod1, prod2 };
            var features = new[] { feat2 };
            var result = linq.ProductsThatDontHaveAnyFeatureInCommon(products, features);
            Assert.Equal(new[] { prod1 }, result);
        }

        [Fact]
        public void MergeCollectionsByProductNameShouldMergeCollectionsByNameAndCalculateTotalQuantity()
        {
            var linq = new LinqMethods();
            Product prod1 = new Product() { Name = "x", Quantity = 2 };
            Product prod2 = new Product() { Name = "x", Quantity = 1 };
            Product prod3 = new Product() { Name = "y", Quantity = 5 };
            var products1 = new[] { prod1, prod3 };
            var products2 = new[] { prod2 };
            var result = linq.MergeCollectionsByProductName(products2, products1);
            Assert.Equal(
                new[]
                {
                    new { Name = "x", Quantity = 3 },
                    new { Name = "y", Quantity = 5 }
                }, result);
        }

        [Fact]
        public void GetFamilyHighScoreShouldReturnHighestScoreForEachFamilyWithoutDuplicates()
        {
            var linq = new LinqMethods();
            var contestant1 = new TestResults { Id = "1", FamilyId = "10", Score = 100 };
            var contestant2 = new TestResults { Id = "2", FamilyId = "20", Score = 99 };
            var contestant3 = new TestResults { Id = "3", FamilyId = "10", Score = 110 };
            var contestant4 = new TestResults { Id = "4", FamilyId = "10", Score = 110 };
            var result = linq.GetFamilyHighScore(
                new[] { contestant1, contestant2, contestant3, contestant4 });
            Assert.Equal(new[] { contestant4, contestant2 }, result);
        }
    }
}
