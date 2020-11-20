using Xunit;

namespace IntegerArray.Facts
{
    public class IntegerArrayFacts
    {
        [Fact]
        public void AddMethodShouldAddGivenElementAfterLastArrayElement()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr[0] == 1 && arr[1] == 5
                     && arr[2] == 2 && arr[3] == 0);
        }

        [Fact]
        public void AddMethodShouldDoubleArraySizeIfNoEmptySpotAvailable()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(5);
            arr.Add(2);
            arr.Add(10);
            arr.Add(9);
            Assert.True(arr[4] == 9 && arr[7] == 0);
        }

        [Fact]
        public void CountMethodShouldReturnNumberOfElementsInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.Count == 2);
        }

        [Fact]
        public void ShouldReturnElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.True(arr[1] == 6);
        }

        [Fact]
        public void ShouldAllowChangeElementValueAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            arr[0] = 3;
            Assert.True(arr[0] == 3 && arr[1] == 6);
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfGivenElementIsFoundInArray()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.True(arr.Contains(1));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfGivenElementIsNotFoundInArray()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.False(arr.Contains(3));
        }

        [Fact]
        public void IndexOfMethodShouldReturnIndexPositionOfGivenElementIfElementIsFound()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.True(arr.IndexOf(6) == 1);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotFound()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.True(arr.IndexOf(3) == -1);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfZeroIsNotAValidElement()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            Assert.True(arr.IndexOf(0) == -1);
        }

        [Fact]
        public void IndexOfMethodIfZeroIsValidElementShouldReturnTheIndex()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(0);
            arr.Add(6);
            Assert.True(arr.IndexOf(0) == 1);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPosition()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            arr.Add(25);
            arr.Insert(3, 1);
            Assert.True(arr[0] == 1 && arr[1] == 3 && arr[2] == 6 && arr[3] == 25);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtFirstPositionIfNoIndexProvided()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            arr.Add(25);
            arr.Insert(3);
            Assert.True(arr[0] == 3 && arr[1] == 1 && arr[2] == 6 && arr[3] == 25);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPositionEvenIfAllPositionsAreFull()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            arr.Add(9);
            arr.Add(11);
            arr.Insert(3, 1);
            Assert.True(arr[0] == 1 && arr[1] == 3 && arr[2] == 6 && arr[4] == 11);
        }

        [Fact]
        public void ClearMethodShouldDeleteAllElements()
        {
            var arr = new IntArray();
            arr.Add(1);
            arr.Add(6);
            arr.Add(3);
            arr.Clear();
            Assert.True(arr.Count == 0);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElement()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(2);
            arr.Remove(2);
            Assert.True(arr[0] == 5 && arr[1] == 3 && arr[2] == 2);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElementIfItsTheLastElementOfTheArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(1);
            arr.Add(3);
            arr.Add(2);
            arr.Remove(2);
            Assert.True(arr[3] == 0);
        }

        [Fact]
        public void RemoveAtMethodShouldRemoveElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(2);
            arr.Add(10);
            arr.RemoveAt(2);
            Assert.True(arr[2] == 2 && arr[3] == 10 && arr[7] == 0);
        }

        [Fact]
        public void RemoveAtMethodShouldRemoveElementAtGivenIndexIfItsTheLastElementInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(2);
            arr.RemoveAt(3);
            Assert.True(arr[3] == 0);
        }
    }
}
