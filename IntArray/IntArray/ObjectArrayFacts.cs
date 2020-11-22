using Xunit;

namespace IntegerArray.Facts
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElements()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            objArray.Add(boxedInt);
            Assert.True(objArray.Count == 1);
        }

        [Fact]
        public void ShouldReturnElementAtGivenIndexPosition()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            objArray.Add(boxedInt);
            Assert.True(objArray[0] == boxedInt);
        }

        [Fact]
        public void ShouldSetElementAtGivenIndexPosition()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
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
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            var intArray = new IntArray();
            var sortedIntArray = new SortedIntArray();
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            objArray.Add(intArray);
            objArray.Add(sortedIntArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == intArray && objArray[3] == sortedIntArray);
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfElementIsInArray()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            Assert.True(objArray.Contains(boxedBool));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfElementIsNotInArray()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
            Assert.False(objArray.Contains(boxedBool));
        }

        [Fact]
        public void IndexOfMethodShouldReturnElementIndexIfIsInArray()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            Assert.True(objArray.IndexOf(boxedBool) == 1);
        }

        [Fact]
        public void IndexOfMethodShouldReturnNegativeOneIfElementIsNotInArray()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
            Assert.True(objArray.IndexOf(boxedBool) == -1);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPosition()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            objArray.Insert(1, intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == intArray && objArray[2] == boxedBool);
        }

        [Fact]
        public void InsertMethodShouldInsertGivenElementAtGivenPositionEvenIfAllPositionsAreFull()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            object boxedString = "abc";
            object boxedChar = 'a';
            object intArray = new IntArray();
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            objArray.Add(boxedString);
            objArray.Add(boxedChar);
            objArray.Insert(1, intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == intArray
                     && objArray[2] == boxedBool && objArray[4] == boxedChar);
        }

        [Fact]
        public void ClearMethodShouldResetElementCount()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            objArray.Add(boxedInt);
            objArray.Add(boxedBool);
            objArray.Clear();
            Assert.True(objArray.Count == 0);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElement()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            objArray.Add(boxedInt);
            objArray.Add(intArray);
            objArray.Add(boxedBool);
            objArray.Add(intArray);
            objArray.Remove(intArray);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == intArray);
        }

        [Fact]
        public void RemoveAtMethodShouldRemoveElementAtGivenIndex()
        {
            var objArray = new ObjectArray();
            object boxedInt = 123;
            object boxedBool = true;
            object intArray = new IntArray();
            objArray.Add(boxedInt);
            objArray.Add(intArray);
            objArray.Add(boxedBool);
            objArray.RemoveAt(1);
            Assert.True(objArray[0] == boxedInt && objArray[1] == boxedBool
                     && objArray[2] == null);
        }
    }
}
