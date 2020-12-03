using Xunit;
using System;
using System.Collections.Generic;

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
        public void AddMethodShouldThrowExceptionIfCollectionIsReadOnly()
        {
            var objArray = new List<object>() { 123, true };
            var intArray = new IntArray();
            List<object> readOnlyObjArray = objArray;
            bool read = readOnlyObjArray.IsReadOnly;
            objArray.Add(intArray);
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
        public void InsertMethodShouldThrowExceptionIfIndexIsLessThanZero()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, true, "abc", 'a' };
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.Insert(-1, intArray));
        }

        [Fact]
        public void InsertMethodShouldThrowExceptionIfIndexIsGreaterThanNumberOfElements()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, true, "abc", 'a' };
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.Insert(5, intArray));
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
        public void RemoveAtMethodShouldThrowExceptionIfIndexIsLessThanZero()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.RemoveAt(-1));
        }

        [Fact]
        public void RemoveAtMethodShouldThrowExceptionIfIndexIsGreaterThenNumberOfElementsInCollection()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.RemoveAt(3));
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
        public void CopyToMethodShouldThrowExceptionIfNumberOfCollectionElementsIsGreaterThanAbailableSpaceInDestinationArray()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = new object[4];
            Assert.Throws<ArgumentException>(() => objArray.CopyTo(newArray, 2));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfDestinationArrayIsNull()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = null;
            Assert.Throws<ArgumentNullException>(() => objArray.CopyTo(newArray, 2));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfIndexIsLessThanZero()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = new object[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.CopyTo(newArray, -1));
        }

        [Fact]
        public void CopyToMethodShouldThrowExceptionIfIndexIsGreaterThanNumberOfAvailablePositions()
        {
            object intArray = new IntArray();
            var objArray = new List<object>() { 123, intArray, true };
            object[] newArray = new object[4];
            Assert.Throws<ArgumentOutOfRangeException>(() => objArray.CopyTo(newArray, 4));
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