using Xunit;

namespace IntegerArray.Facts
{
    public class IntegerArrayFacts
    {
        [Fact]
        public void Add_ShouldAddGivenElementAfterLastArrayElement()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1 };
            arr.count = 1;
            arr.Add(5);
            arr.Add(2);
            Assert.True(arr.data[1] == 5 && arr.data[2] == 2 && arr.data[3] == 0);
        }

        [Fact]
        public void Add_ShouldDoubleArraySizeIfNoEmptySpotAvailable()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 5, 2, 10 };
            arr.count = 4;
            arr.Add(9);
            Assert.True(arr.data[0] == 1 && arr.data[1] == 5 && arr.data[2] == 2
                     && arr.data[3] == 10 && arr.data[4] == 9 && arr.data[5] == 0
                     && arr.data[6] == 0 && arr.data[7] == 0);
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
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.True(arr.Element(1) == 6);
        }

        [Fact]
        public void SetElement_ShouldChangeElementValueAtGivenIndex()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            arr.SetElement(0, 3);
            Assert.True(arr.data[0] == 3);
        }

        [Fact]
        public void Contains_ShouldReturnTrueIfGivenElementIsFoundInArray()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.True(arr.Contains(1));
        }

        [Fact]
        public void Contains_ShouldReturnFalseIfGivenElementIsNotFoundInArray()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.False(arr.Contains(3));
        }

        [Fact]
        public void IndexOf_ShouldReturnIndexPositionOfGivenElementIfElementIsFound()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.True(arr.IndexOf(6) == 1);
        }

        [Fact]
        public void IndexOf_ShouldReturnNegativeOneIfElementIsNotFound()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.True(arr.IndexOf(3) == -1);
        }

        [Fact]
        public void IndexOf_ShouldReturnNegativeOneIfZeroIsNotAValidElement()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0 };
            arr.count = 2;
            Assert.True(arr.IndexOf(0) == -1);
        }

        [Fact]
        public void IndexOf_IfZeroIsValidElementShouldReturnTheIndex()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 0, 6, 0 };
            arr.count = 3;
            Assert.True(arr.IndexOf(0) == 1);
        }

        [Fact]
        public void Insert_ShouldInsertGivenElementAtGivenPosition()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 0, 0};
            arr.count = 2;
            arr.Insert(1, 3);
            Assert.True(arr.data[0] == 1 && arr.data[1] == 3 && arr.data[2] == 6
                        && arr.data[3] == 0);
        }

        [Fact]
        public void Clear_ShouldDeleteAllElements()
        {
            var arr = new IntArray();
            arr.data = new int[] { 1, 6, 3, 0 };
            arr.count = 3;
            arr.Clear();
            Assert.True(arr.count == 0 && arr.data.Length == 4);
        }

        [Fact]
        public void Remove_ShouldRemoveFirstOccurenceOfGivenElement()
        {
            var arr = new IntArray();
            arr.data = new int[] { 5, 2, 3, 2, 10, 0, 0, 0 };
            arr.count = 5;
            arr.Remove(2);
            Assert.True(arr.data[0] == 5 && arr.data[1] == 3 && arr.data[2] == 2
                     && arr.data[3] == 10 && arr.data[4] == 0 && arr.data[5] == 0
                     && arr.data[6] == 0 && arr.data[7] == 0);
        }

        [Fact]
        public void RemoveAt_ShouldRemoveElementAtGivenIndex()
        {
            var arr = new IntArray();
            arr.data = new int[] { 5, 2, 3, 2, 10, 0, 0, 0 };
            arr.count = 5;
            arr.RemoveAt(2);
            Assert.True(arr.data[0] == 5 && arr.data[1] == 2 && arr.data[2] == 2 
                     && arr.data[3] == 10 && arr.data[4] == 0 && arr.data[5] == 0
                     && arr.data[6] == 0 && arr.data[7] == 0);
        }
    }
}
