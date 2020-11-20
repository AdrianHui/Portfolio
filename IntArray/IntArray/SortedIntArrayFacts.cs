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
        public void InsertMethodShouldInsertElementInArrayAtCorectPosition()
        {
            var sorted = new SortedIntArray();
            sorted.Add(5);
            sorted.Add(9);
            sorted.Add(3);
            sorted.Insert(7);
            Assert.True(sorted[0] == 3 && sorted[1] == 5 && sorted[2] == 7 && sorted[3] == 9);
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
    }
}
