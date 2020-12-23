using System;
using System.Collections.Generic;
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
    }
}
