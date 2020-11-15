using Xunit;

namespace IntegerArray.Facts
{
    public class IntegerArrayFacts
    {
        [Fact]
        public void Add_ShouldAddTheIntToTheEndOfTheArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.data[0] == 5 && arr.data[1] == 2);
        }

        [Fact]
        public void Count_ShouldReturnNumberOfElementsInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.Count() == 2);
        }

        [Fact]
        public void Element_ShouldReturnElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.Element(1) == 2);
        }

        [Fact]
        public void SetElement_ShouldChangeElementValueAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.SetElement(0, 3);
            Assert.True(arr.data[0] == 3);
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfGivenElementIsFoundInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.Contains(2));
        }

        [Fact]
        public void Contains_ShouldReturnFalseIfGivenElementIsNotFoundInArray()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.False(arr.Contains(3));
        }

        [Fact]
        public void IndexOf_ShouldReturnIndexPositionOfGivenElementIfElementIsFound()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.IndexOf(2) == 1);
        }

        [Fact]
        public void IndexOf_ShouldReturnNegativeOneIfElementIsNotFound()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.IndexOf(3) == -1);
        }

        [Fact]
        public void Insert_ShouldInsertGivenElementAtGivenPosition()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Insert(1, 3);
            Assert.True(arr.data[1] == 3 && arr.data[2] == 2);
        }

        [Fact]
        public void Clear_ShouldDeleteAllElements()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Insert(1, 3);
            arr.Clear();
            Assert.True(arr.count == 0 && arr.data.Length == 0);
        }

        [Fact]
        public void Remove_ShouldRemoveFirstOccurenceOfGivenElement()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(2);
            arr.Remove(2);
            Assert.True(arr.data[0] == 5 && arr.data[1] == 3 && arr.data[2] == 2);
        }

        [Fact]
        public void RemoveAt_ShouldRemoveElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.Add(5);
            arr.Add(2);
            arr.Add(3);
            arr.Add(2);
            arr.RemoveAt(2);
            Assert.True(arr.data[0] == 5 && arr.data[1] == 2 && arr.data[2] == 2);
        }
    }
}
