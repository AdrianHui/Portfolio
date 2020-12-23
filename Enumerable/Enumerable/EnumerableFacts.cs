using System;
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
    }
}
