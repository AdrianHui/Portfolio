using Xunit;

namespace IntegerArray.Facts
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElements()
        {
            object boxedInt = 123;
            var objArray = new ObjectArray() { boxedInt };
            Assert.True(objArray.Count == 1);
        }

        [Fact]
        public void ShouldReturnElementAtGivenIndexPosition()
        {
            object boxedInt = 123;
            var objArray = new ObjectArray() { boxedInt };
            Assert.True(objArray[0] == boxedInt);
        }

        [Fact]
        public void ShouldSetElementAtGivenIndexPosition()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt };
            objArray[0] = boxedBool;
            Assert.True(objArray[0] == boxedBool);
        }

        [Fact]
        public void AddMethodShouldAllowAddingBasicTypes()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            object boxedString = "abc";
            object boxedChar = 'a';
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            objArray.Add(boxedString);
            objArray.Add(boxedChar);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == boxedString && objArray[3] == boxedChar);
        }

        [Fact]
        public void AddMethodShouldAllowAddingOtherObjectInstances()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var intArray = new IntArray();
            var sortedIntArray = new SortedIntArray();
            var objArray = new ObjectArray() { boxedInt, boxedBool };
            objArray.Add(intArray);
            objArray.Add(sortedIntArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == intArray && objArray[3] == sortedIntArray);
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementIsInArray()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt, boxedBool };
            Assert.True(objArray.Contains(boxedBool));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementIsNotInArray()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt };
            Assert.False(objArray.Contains(boxedBool));
        }

        [Fact]
        public void IndexOfMethodShouldReturnElementIndexIfIsInArray()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt, boxedBool };
            Assert.True(objArray.IndexOf(boxedBool) == 1);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotInArray()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt };
            Assert.True(objArray.IndexOf(boxedBool) == -1);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPosition()
        {
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            var objArray = new ObjectArray() { boxedInt, boxedBool };
            objArray.Insert(1, intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == intArray && objArray[2] == boxedBool);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPositionEvenIfAllPositionsAreFull()
        {
            object boxedInt = 123;
            object boxedBool = true;
            object boxedString = "abc";
            object boxedChar = 'a';
            object intArray = new IntArray();
            var objArray = new ObjectArray() { boxedInt, boxedBool, boxedString, boxedChar, intArray };
            objArray.Insert(1, intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == intArray
                     && objArray[2] == boxedBool && objArray[4] == boxedChar);
        }

        [Fact]
        public void ClearMethodShouldResetElementCount()
        {
            object boxedInt = 123;
            object boxedBool = true;
            var objArray = new ObjectArray() { boxedInt, boxedBool };
            objArray.Clear();
            Assert.True(objArray.Count == 0);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElement()
        {
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            var objArray = new ObjectArray() { boxedInt, intArray, boxedBool, intArray };
            objArray.Remove(intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == intArray);
        }

        [Fact]
        public void RemoveAtMethodShouldRemoveElementAtGivenIndex()
        {
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            var objArray = new ObjectArray() { boxedInt, intArray, boxedBool };
            objArray.RemoveAt(1);

            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == null);
        }
    }
}
