using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Enumerable.Facts
{
    public class EnumerableFacts
    {
        [Fact]
        public void AllShouldReturnTrueIfAllElementsMeetTheCondition()
        {
            int[] absNums = { 1, 45, 376 };
            Assert.True(absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldReturnFalseIfAtLeastOneElementDoesntMeetTheCondition()
        {
            int[] absNums = { 1, 45, -376 };
            Assert.False(absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.All(num => num > 0));
        }

        [Fact]
        public void AllShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.All(null));
        }

        [Fact]
        public void AnyShouldReturnTrueIfAtLeastOneElementMeetTheCondition()
        {
            int[] absNums = { -1, 45, -376 };
            Assert.True(absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldReturnFalseIfAllElementsDoesntMeetTheCondition()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.False(absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.Any(num => num > 0));
        }

        [Fact]
        public void AnyShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.Any(null));
        }

        [Fact]
        public void FirstShouldReturnFirstElementThatMeetTheCondition()
        {
            int[] absNums = { -1, -45, 376 };
            Assert.True(absNums.First(num => num > 0) == 376);
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfNoneOfTheElementsMeetTheCondition()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.Throws<InvalidOperationException>(() => absNums.First(num => num > 0));
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfCollectionIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(() => absNums.First(num => num > 0));
        }

        [Fact]
        public void FirstShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = { -1, -45, -376 };
            Assert.Throws<ArgumentNullException>(() => absNums.First(null));
        }

        [Fact]
        public void SelectShouldReturnACollectionWithElementsInNewFormIndicatedBySelector()
        {
            int[] absNums = { -1, -45, -376 };
            IEnumerable<int> newCollection = absNums.Select(num => Math.Abs(num));
            Assert.Equal(new[] { 1, 45, 376 }, newCollection);
        }

        [Fact]
        public void SelectShouldThrowAnExceptionIfSourceCollectionIsNull()
        {
            int[] absNums = null;
            IEnumerable<int> newCollection = absNums.Select(num => Math.Abs(num));
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void SelectManyShouldReturnACollectionWithElementsInNewFormIndicatedBySelector()
        {
            int[][] nums =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 }
            };
            IEnumerable<int> newCollection = nums.SelectMany(num => num);
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, newCollection);
        }

        [Fact]
        public void SelectManyShouldThrowAnExceptionIfSourceCollectionIsNull()
        {
            int[][] nums = null;
            IEnumerable<int> newCollection = nums.SelectMany(num => num);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void WhereShouldReturnANewCollectionWithElementThatMeetTheCondition()
        {
            int[] absNums = { 1, -45, 376 };
            IEnumerable<int> newCollection = absNums.Where(num => num > 0);
            Assert.Equal(new[] { 1, 376 }, newCollection);
        }

        [Fact]
        public void WhereShouldShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            IEnumerable<int> newCollection = absNums.Where(num => num > 0);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void WhereShouldShouldThrowAnExceptionIfPredicateIsNull()
        {
            int[] absNums = { 1, -45, 376 };
            IEnumerable<int> newCollection = absNums.Where(null);
            Assert.Throws<ArgumentNullException>(() => newCollection.All(num => num > 0));
        }

        [Fact]
        public void ToDictionaryShouldReturnADictionaryWithKeysAndValuesAccordingToSelectors()
        {
            int[] absNums = { 1, 2, 3, 4 };
            Dictionary<int, string> dict =
                absNums.ToDictionary(key => key * 2, val => val.ToString());
            Assert.True(dict[2] == "1" && dict[4] == "2"
                && dict[6] == "3" && dict[8] == "4");
        }

        [Fact]
        public void ToDictionaryShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(()
                => absNums.ToDictionary(key => key * 2, val => val.ToString()));
        }

        [Fact]
        public void ZipShouldReturnANewCollectionSameSizeAsShortestContainingFirstAndSecondCollectionsElementsMerged()
        {
            int[] absNums = { 1, 2, 3, 4 };
            string[] strings = { "one", "two", "three" };
            IEnumerable<string> newCollection =
                absNums.Zip(strings, (first, second) => first + " - " + second);
            Assert.Equal(new[] { "1 - one", "2 - two", "3 - three" }, newCollection);
        }

        [Fact]
        public void ZipShouldThrowAnExceptionIfFirstCollectionIsNull()
        {
            int[] first = null;
            string[] second = { "one", "two", "three" };
            IEnumerable<string> newCollection =
                first.Zip(second, (first, second) => first + " - " + second);
            Assert.Throws<ArgumentNullException>(()
                => newCollection.All(predicate => predicate != null));
        }

        [Fact]
        public void ZipShouldThrowAnExceptionIfSecondCollectionIsNull()
        {
            int[] first = { 1, 2, 3, 4 };
            string[] second = null;
            IEnumerable<string> newCollection =
                first.Zip(second, (first, second) => first + " - " + second);
            Assert.Throws<ArgumentNullException>(()
                => newCollection.All(predicate => predicate != null));
        }

        [Fact]
        public void AggregateShouldApplyAccumulatorFuncOverEachElementInTheCollectionAndReturnTheResult()
        {
            int[] absNums = { 1, 2, 3, 4 };
            var result = absNums.Aggregate(0, (sum, current) => sum + current);
            Assert.Equal(10, result);
        }

        [Fact]
        public void AggregateShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] absNums = null;
            Assert.Throws<ArgumentNullException>(()
                => absNums.Aggregate(0, (sum, current) => sum + current));
        }

        [Fact]
        public void AggregateShouldThrowAnExceptionIfFuncIsNull()
        {
            int[] absNums = { 1, 2, 3, 4 };
            Assert.Throws<ArgumentNullException>(()
                => absNums.Aggregate(0, null));
        }

        [Fact]
        public void JoinShouldReturnACollectionWithElementsThatHaveCommonKeys()
        {
            int[] outer = { 1, 2, 3, 4 };
            int[] inner = { 1, 2, 5, 6 };
            var result = outer.Join(
                inner,
                outerKey => outerKey,
                innerKey => innerKey,
                (outer, inner) => outer + " - " + inner);
            Assert.Equal(new[] { "1 - 1", "2 - 2" }, result);
        }

        [Fact]
        public void JoinShouldThrowAnExceptionIfOuterCollectionIsNull()
        {
            int[] outer = null;
            int[] inner = { 1, 2, 5, 6 };
            var result = outer.Join(
                inner,
                outerKey => outerKey,
                innerKey => innerKey,
                (outer, inner) => outer + " - " + inner);
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void JoinShouldThrowAnExceptionIfInnerCollectionIsNull()
        {
            int[] outer = { 1, 2, 3, 4 };
            int[] inner = null;
            var result = outer.Join(
                inner,
                outerKey => outerKey,
                innerKey => innerKey,
                (outer, inner) => outer + " - " + inner);
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void JoinShouldThrowAnExceptionIfOuterKeySelectorIsNull()
        {
            int[] outer = { 1, 2, 3, 4 };
            int[] inner = { 1, 2, 5, 6 };
            var result = outer.Join(
                inner,
                null,
                innerKey => innerKey,
                (outer, inner) => outer + " - " + inner);
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void JoinShouldThrowAnExceptionIfInnerKeySelectorIsNull()
        {
            int[] outer = { 1, 2, 3, 4 };
            int[] inner = { 1, 2, 5, 6 };
            var result = outer.Join(
                inner,
                outerKey => outerKey,
                null,
                (outer, inner) => outer + " - " + inner);
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void DistinctShouldReturnACollectionContainingOnlyUniqueElements()
        {
            int[] source = { 1, 2, 3, 2 };
            var result = source.Distinct(new CustomEqualityComparer<int>());
            Assert.Equal(new[] { 1, 2, 3 }, result);
        }

        [Fact]
        public void DistinctShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] source = null;
            var result = source.Distinct(new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void UnionShouldReturnACollectionContainingOnlyUniqueElementsFromBothCollections()
        {
            int[] first = { 1, 2, 3, 2 };
            int[] second = { 5, 3, 6, 2 };
            var result = first.Union(second, new CustomEqualityComparer<int>());
            Assert.Equal(new[] { 1, 2, 3, 5, 6 }, result);
        }

        [Fact]
        public void UnionShouldThrowAnExceptionIfFirstCollectionIsNull()
        {
            int[] first = null;
            int[] second = { 5, 3, 6, 2 };
            var result = first.Union(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void UnionShouldThrowAnExceptionIfSecondCollectionIsNull()
        {
            int[] first = { 1, 2, 3, 2 };
            int[] second = null;
            var result = first.Union(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void IntersectShouldReturnACollectionContainingElementsThatCanBeFoundInBothCollections()
        {
            int[] first = { 1, 2, 3, 2 };
            int[] second = { 5, 3, 6, 2 };
            var result = first.Intersect(second, new CustomEqualityComparer<int>());
            Assert.Equal(new[] { 2, 3 }, result);
        }

        [Fact]
        public void IntersectShouldThrowAnExceptionIfFirstCollectionIsNull()
        {
            int[] first = null;
            int[] second = { 5, 3, 6, 2 };
            var result = first.Intersect(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void IntersectShouldThrowAnExceptionIfSecondCollectionIsNull()
        {
            int[] first = { 1, 2, 3, 2 };
            int[] second = null;
            var result = first.Intersect(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void ExceptShouldReturnACollectionContainingElementsFromFirstCollectionThatCanNotBeFoundInSecondCollections()
        {
            int[] first = { 1, 2, 3, 2, 4 };
            int[] second = { 5, 3, 6, 2 };
            var result = first.Except(second, new CustomEqualityComparer<int>());
            Assert.Equal(new[] { 1, 4 }, result);
        }

        [Fact]
        public void ExceptShouldThrowAnExceptionIfFirstCollectionIsNull()
        {
            int[] first = null;
            int[] second = { 5, 3, 6, 2 };
            var result = first.Except(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void ExceptShouldThrowAnExceptionIfSecondCollectionIsNull()
        {
            int[] first = { 1, 2, 3, 2, 4 };
            int[] second = null;
            var result = first.Except(second, new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void GroupByShouldGroupElementsByKeySelectorAndReturnTheResultsAccordingToResultSelector()
        {
            int[] source = { 1, 1, 2, 1, 2, 3, 1, 2, 3, 4 };
            var result = source.GroupBy(
                x => x,
                y => y,
                (key, values) => $"{key} occurs {values.Count()} times",
                new CustomEqualityComparer<int>());
            Assert.Equal(
                new[]
                {
                    "1 occurs 4 times", "2 occurs 3 times", "3 occurs 2 times", "4 occurs 1 times"
                }, result);
        }

        [Fact]
        public void GroupByShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] source = null;
            var result = source.GroupBy(
                x => x,
                y => y,
                (key, values) => $"{key} occurs {values.Count()} times",
                new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void GroupByShouldThrowAnExceptionIfKeySelectorIsNull()
        {
            int[] source = { 1, 1, 2, 1, 2, 3, 1, 2, 3, 4 };
            var result = source.GroupBy(
                null,
                y => y,
                (key, values) => $"{key} occurs {values.Count()} times",
                new CustomEqualityComparer<int>());
            Assert.Throws<ArgumentNullException>(() => result.All(predicate => predicate != null));
        }

        [Fact]
        public void OrderByShouldOrderElementsByKeyInAscendingOrder()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            var result = source.OrderBy(
                x => x,
                new CustomComparer<int>());
            Assert.Equal(new[] { 3, 4, 4, 5, 8 }, result);
        }

        [Fact]
        public void OrderByShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] source = null;
            Assert.Throws<ArgumentNullException>(() =>
                            source.OrderBy(x => x, new CustomComparer<int>()));
        }

        [Fact]
        public void OrderByShouldThrowAnExceptionIfKeySelectorIsNull()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            Assert.Throws<ArgumentNullException>(() =>
                            source.OrderBy(null, new CustomComparer<int>()));
        }

        [Fact]
        public void OrderByShouldThrowAnExceptionIfComparerIsNull()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            Assert.Throws<ArgumentNullException>(() =>
                            source.OrderBy(x => x, null));
        }

        [Fact]
        public void ThenByShouldOrderElementsByKeyInAscendingOrder()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            var result = source.OrderBy(
                x => x,
                new CustomComparer<int>()).ThenBy(
                x => x % 2,
                new CustomComparer<int>());
            Assert.Equal(new[] { 4, 4, 8, 3, 5 }, result);
        }

        [Fact]
        public void ThenByShouldThrowAnExceptionIfSourceIsNull()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            IOrderedEnumerable<int> ord = null;
            Assert.Throws<ArgumentNullException>(() =>
                            ord.ThenBy(x => x % 2, new CustomComparer<int>()));
        }

        [Fact]
        public void ThenByShouldThrowAnExceptionIfKeySelectorIsNull()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            IOrderedEnumerable<int> ord = source.OrderBy(
                x => x,
                new CustomComparer<int>());
            Assert.Throws<ArgumentNullException>(() =>
                            ord.ThenBy(null, new CustomComparer<int>()));
        }

        [Fact]
        public void ThenByShouldThrowAnExceptionIfComparerIsNull()
        {
            int[] source = { 5, 8, 4, 4, 3 };
            IOrderedEnumerable<int> ord = source.OrderBy(
                x => x,
                new CustomComparer<int>());
            Assert.Throws<ArgumentNullException>(() =>
                            ord.ThenBy(x => x % 2, null));
        }
    }
}