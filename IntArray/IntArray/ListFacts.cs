using Xunit;

namespace IntegerArray.Facts
{
    public class ListFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElements()
        {
            var objArray = new List<object>() { 123 };
            Assert.True(objArray.Count == 1);
        }

        [Fact]
        public void ShouldReturnElementAtGivenIndexPosition()
        {
            var objArray = new List<object>() { 123 };
            Assert.True(objArray[0].Equals(123));
        }

        [Fact]
        public void ShouldSetElementAtGivenIndexPosition()
        {
            var objArray = new List<object>() { 123 };
            objArray[0] = true;
            Assert.True(objArray[0].Equals(true));
        }

        [Fact]
        public void AddMethodShouldAllowAddingBasicTypes()
        {
            var objArray = new List<object>();
            objArray.Add(123);
            objArray.Add(true);
            objArray.Add("abc");
            objArray.Add('a');
            Assert.True(objArray[0].Equals(123) && objArray[1].Equals(true)
                     && objArray[2].Equals("abc") && objArray[3].Equals('a'));
        }

        [Fact]
        public void AddMethodShouldAllowAddingOtherObjectInstances()
        {
            var objArray = new List<object>() { 123, true };
            var intArray = new IntArray();
            var sortedIntArray = new SortedIntArray();
            objArray.Add(intArray);
            objArray.Add(sortedIntArray);
            Assert.True(objArray[0].Equals(123) && objArray[1].Equals(true)
                     && objArray[2].Equals(intArray) && objArray[3].Equals(sortedIntArray));
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementIsInArray()
        {
            var objArray = new List<object>() { 123, true };
            Assert.True(objArray.Contains(123));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementIsNotInArray()
        {
            var objArray = new List<object>() { 123 };
            Assert.False(objArray.Contains(true));
        }

        [Fact]
        public void IndexOfMethodShouldReturnElementIndexIfIsInArray()
        {
            var objArray = new List<object>() { 123, true };
            Assert.True(objArray.IndexOf(123) == 0);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotInArray()
        {
            var objArray = new List<object>() { 123 };
            Assert.True(objArray.IndexOf(true) == -1);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPosition()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, true };
            objArray.Insert(1, intArray);
            Assert.True(objArray[0].Equals(123) && objArray[1].Equals(intArray)
                     && objArray[2].Equals(true));
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPositionEvenIfAllPositionsAreFull()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, true, "abc", 'a' };
            objArray.Insert(1, intArray);
            Assert.True(objArray[0].Equals(123) && objArray[1].Equals(intArray)
                     && objArray[2].Equals(true) && objArray[4].Equals('a'));
        }

        [Fact]
        public void ClearMethodShouldResetElementCount()
        {
            var objArray = new List<object>() { 123, true };
            objArray.Clear();
            Assert.True(objArray.Count == 0);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElementAndReturnTrue()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true, intArray };
            Assert.True(objArray.Remove(intArray) && objArray[0].Equals(123)
                     && objArray[1].Equals(true) && objArray.Count == 3);
        }

        [Fact]
        public void RemoveMethodShouldReturnFalseIfElementWasNotFoundInArray()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true, intArray };
            Assert.False(objArray.Remove(5));
        }

        [Fact]
        public void RemoveAtMethodShouldRemoveElementAtGivenIndex()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            objArray.RemoveAt(1);

            Assert.True(objArray[0].Equals(123) && objArray[1].Equals(true)
                     && objArray.Count == 2);
        }

        [Fact]
        public void CopyToMethodShouldCopyCollectionElementsToGivenArrayStartingAtGivenIndex()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = new object[4];
            newArray[0] = 'a';
            objArray.CopyTo(newArray, 1);

            Assert.True(newArray[0].Equals('a') && newArray[1].Equals(123)
                     && newArray[2].Equals(intArray) && newArray[3].Equals(true));
        }

        [Fact]
        public void CopyToMethodShouldNotCopyIfGivenArrayHasFewerEmptySpotsAfterGivenIndexThanCollectionElements()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = new object[4];
            newArray[0] = 'a';
            newArray[1] = "abc";
            objArray.CopyTo(newArray, 2);

            Assert.True(newArray[0].Equals('a') && newArray[1].Equals("abc")
                     && newArray[2] == null && newArray[3] == null);
        }

        [Fact]
        public void IsReadOnlyPropertyShouldReturnFalse()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            Assert.False(objArray.IsReadOnly);
        }
    }
}