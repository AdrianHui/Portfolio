using System;
using Xunit;

namespace IntegerArray.Facts
{
    public class ReadOnlyListFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElements()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.True(readOnlyList.Count == 2);
        }

        [Fact]
        public void IsReadOnlyShouldReturnTrue()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.True(readOnlyList.IsReadOnly);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToSetAnElement()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList[0] = 1);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToAddAnElement()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Add(1));
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementIsInArray()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.True(readOnlyList.Contains(23));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementIsNotInArray()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.False(readOnlyList.Contains(true));
        }

        [Fact]
        public void IndexOfMethodShouldReturnElementIndexIfIsInArray()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.True(readOnlyList.IndexOf(23) == 1);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotInArray()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.True(readOnlyList.IndexOf(true) == -1);
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToInsertAnElement()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Insert(1, 'c'));
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToClearCollection()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Clear());
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToRemoveAnElement()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.Remove(23));
        }

        [Fact]
        public void ShouldThrowAnExceptionWhenTryingToRemoveElementAtGivenIndex()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            Assert.Throws<NotSupportedException>(() => readOnlyList.RemoveAt(1));
        }

        [Fact]
        public void CopyToMethodShouldCopyCollectionElementsToGivenArrayStartingAtGivenIndex()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            object[] newArray = new object[4];
            readOnlyList.CopyTo(newArray, 1);

            Assert.True(newArray[0] == null && newArray[1].Equals("ad")
                     && newArray[2].Equals(23) && newArray[3] == null);
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfNumberOfCollectionElementsIsGreaterThanAbailableSpaceInDestinationArray()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            object[] newArray = new object[4];
            Assert.Throws<ArgumentException>(() => readOnlyList.CopyTo(newArray, 3));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfDestinationArrayIsNull()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            object[] newArray = null;
            Assert.Throws<ArgumentNullException>(() => readOnlyList.CopyTo(newArray, 2));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfIndexIsLessThanZero()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            object[] newArray = new object[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => readOnlyList.CopyTo(newArray, -1));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfIndexIsGreaterThanNumberOfAvailablePositions()
        {
            var list = new List<object> { "ad", 23 };
            var readOnlyList = new ReadOnlyList<object>(list);
            object[] newArray = new object[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => readOnlyList.CopyTo(newArray, 4));
        }
    }
}
