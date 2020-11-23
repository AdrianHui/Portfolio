using Xunit;

namespace IntegerArray.Facts
{
    public class SortedIntArrayFacts
    {
        [Fact]
        public void AddMethodShouldAddElementsInOrder()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 9 && sorted[3] == 0);
        }

        [Fact]
        public void AddMethodShouldDoubleArraySizeIfNoEmptySpotAvailable()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            sorted.Add(0);
            sorted.Add(11);
            Assert.True(sorted[0] == 0 && sorted[2] == 5 && sorted[4] == 11 && sorted[7] == 0);
        }

        [Fact]
        public void InsertMethodShouldInsertElementAtGivenPositionIfIsInAscendingOrder()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted.Insert(1, 4);
            Assert.True(sorted[0] == 3 && sorted[1] == 4 && sorted[2] == 5 && sorted[3] == 9);
        }

        [Fact]
        public void InsertMethodShouldInsertElementAtGivenPositionIfIsEqualToCurrentElement()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted.Insert(1, 5);
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 5 && sorted[3] == 9);
        }

        [Fact]
        public void InsertMethodShouldInsertElementAtGivenPositionIfElementBeforeIsEqual()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted.Insert(1, 3);
            Assert.True(sorted[0] == 3 && sorted[1] == 3 && sorted[2] == 5 && sorted[3] == 9);
        }

        [Fact]
        public void InsertMethodShouldNotInsertElementAtGivenPositionIfIsNotInAscendingOrder()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted.Insert(1, 11);
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 9 && sorted[3] == 0);
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementIsInArray()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            Assert.True(sorted.Contains(3));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementIsNotInArray()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            Assert.False(sorted.Contains(20));
        }

        [Fact]
        public void IndexOfMethodShouldReturnElementIndexIfIsInArray()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            Assert.True(sorted.IndexOf(3) == 0);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotInArray()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            Assert.True(sorted.IndexOf(20) == -1);
        }

        [Fact]
        public void ClearMethodShouldResetCount()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            sorted.Clear();
            Assert.True(sorted.Count == 0);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfAnElement()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            sorted.Add(5);
            sorted.Remove(5);
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 9);
        }

        [Fact]
        public void ShouldSetElementAtGivenPositionIfIsInAscendingrder()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted[1] = 7;
            Assert.True(sorted[0] == 3 && sorted[1] == 7 && sorted[2] == 9);
        }

        [Fact]
        public void ShouldSetElementAtIndexZeroIfNextElementIsGreater()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted[0] = 4;
            Assert.True(sorted[0] == 4 && sorted[1] == 5 && sorted[2] == 9);
        }

        [Fact]
        public void ShouldSetElementAtGivenIndexIfNextElementIsEqual()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted[0] = 5;
            Assert.True(sorted[0] == 5 && sorted[1] == 5 && sorted[2] == 9);
        }

        [Fact]
        public void ShouldSetElementAtGivenIndexIfElementBeforeIsEqual()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted[1] = 3;
            Assert.True(sorted[0] == 3 && sorted[1] == 3 && sorted[2] == 9);
        }

        [Fact]
        public void ShouldNotSetElementAtGivenPositionIfIsNotInAscendingOrder()
        {
            var sorted = new SortedIntArray();
            sorted.Add(3);
            sorted.Add(5);
            sorted.Add(9);
            sorted[1] = 10;
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 9 && sorted[3] == 0);
        }
    }
}
