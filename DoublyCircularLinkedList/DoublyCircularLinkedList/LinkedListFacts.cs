using System;
using Xunit;

namespace DoublyCircularLinkedList.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElementsInList()
        {
            var list = new LinkedList<int>() { 2, 4, 6 };
            Assert.True(list.Count == 3);
        }

        [Fact]
        public void IsReadOnlyShouldReturnFalse()
        {
            var list = new LinkedList<int>();
            Assert.False(list.IsReadOnly);
        }

        [Fact]
        public void AddFirstMethodShouldAddTheItemAsFirstAndLastElementIfListIsEmpty()
        {
            var list = new LinkedList<int>();
            list.AddFirst(1);
            Assert.True(list.First.Data == 1 && list.Last.Data == 1);
        }

        [Fact]
        public void AddFirstMethodShouldAddElementsAsValuesAtTheBeginingOfTheList()
        {
            var list = new LinkedList<int>();
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Previous.Data == 2 && list.Last.Data == 3);
        }

        [Fact]
        public void AddFirstMethodShouldAddElementsAsNodesAtTheBeginingOfTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddFirst(third);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.True(list.First == first && list.First.Next == second
                && list.Last.Previous == second && list.Last == third);
        }

        [Fact]
        public void AddFirstMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = null;
            Assert.Throws<ArgumentNullException>(() => list.AddFirst(first));
        }

        [Fact]
        public void AddFirstMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            var anotherList = new LinkedList<int>();
            anotherList.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddFirst(first));
        }

        [Fact]
        public void AddLastMethodShouldAddElementAsFirstAndLastElementIfListIsEmpty()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            Assert.True(list.First.Data == 1 && list.Last.Data == 1);
        }

        [Fact]
        public void AddLastMethodShouldAddElementsAsValuesAtTheEndOfTheList()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Data == 3);
        }

        [Fact]
        public void AddLastMethodShouldAddElementsAsNodesAtTheEndOfTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddLast(first);
            list.AddLast(second);
            list.AddLast(third);
            Assert.True(list.First == first && list.First.Next == second
                && list.Last == third);
        }

        [Fact]
        public void AddLastMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = null;
            Assert.Throws<ArgumentNullException>(() => list.AddLast(first));
        }

        [Fact]
        public void AddLastMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            var anotherList = new LinkedList<int>();
            anotherList.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddLast(first));
        }

        [Fact]
        public void AddAfterMethodShouldAddElementsAsValueAfterGivenNode()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            list.AddAfter(list.First.Next, 3);
            Assert.True(list.First.Next.Data == 2 && list.Last.Previous.Data == 3
                && list.Last.Data == 4);
        }

        [Fact]
        public void AddAfterMethodShouldAddElementsAsNodesAfterGivenNode()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            list.AddAfter(list.First.Next, new Node<int>(3));
            Assert.True(list.First.Next.Data == 2 && list.Last.Previous.Data == 3
                && list.Last.Data == 4);
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNodeIsNull()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> node = null;
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(node, new Node<int>(3)));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> newNode = null;
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(list.First.Next, newNode));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNodeCannotBeFoundInCurrentList()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> fifth = new Node<int>(5);
            Assert.Throws<InvalidOperationException>(() => list.AddAfter(fifth, new Node<int>(3)));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            var anotherList = new LinkedList<int>();
            var newNode = new Node<int>(3);
            anotherList.AddLast(newNode);
            Assert.Throws<InvalidOperationException>(() => list.AddAfter(list.First.Next, newNode));
        }

        [Fact]
        public void AddAfterMethodShouldNotThrowAnExceptionIfNewNodeIsStringTypeAndNull()
        {
            var list = new LinkedList<string>();
            Node<string> first = new Node<string>("a");
            Node<string> second = new Node<string>("b");
            Node<string> newNode = new Node<string>(null);
            list.AddFirst(second);
            list.AddFirst(first);
            list.AddAfter(second, newNode);
            Assert.True(list.First == first && list.Last == newNode);
        }

        [Fact]
        public void AddAfterMethodShouldNotThrowAnExceptionIfNewNodeIsObjectTypeAndNull()
        {
            var list = new LinkedList<object>();
            Node<object> first = new Node<object>("a");
            Node<object> second = new Node<object>(1);
            Node<object> newNode = new Node<object>(null);
            list.AddFirst(second);
            list.AddFirst(first);
            list.AddAfter(second, newNode);
            Assert.True(list.First == first && list.Last == newNode);
        }

        [Fact]
        public void AddBeforeMethodShouldAddElementAsValueBeforeGivenNode()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            list.AddBefore(list.Last, 3);
            Assert.True(list.First.Next.Next.Data == 3);
        }

        [Fact]
        public void AddBeforeMethodShouldAddElementAsNodeBeforeGivenNode()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            list.AddBefore(list.Last, new Node<int>(3));
            Assert.True(list.First.Next.Next.Data == 3);
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNodeIsNull()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> node = null;
            Assert.Throws<ArgumentNullException>(() => list.AddBefore(node, new Node<int>(3)));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> newNode = null;
            Assert.Throws<ArgumentNullException>(() => list.AddBefore(list.Last, newNode));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNodeCannotBeFoundInCurrentList()
        {
            var list = new LinkedList<int>() { 1, 2 };
            var node = new Node<int>(4);
            Assert.Throws<InvalidOperationException>(() => list.AddBefore(node, new Node<int>(3)));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>() { 1, 2, 4 };
            Node<int> newNode = new Node<int>(3);
            Node<int> node = new Node<int>(4);
            newNode.Next = node;
            newNode.Previous = node;
            Assert.Throws<InvalidOperationException>(() => list.AddBefore(list.Last, newNode));
        }

        [Fact]
        public void AddBeforeMethodShouldNotThrowAnExceptionIfNewNodeIsStringTypeAndNull()
        {
            var list = new LinkedList<string>();
            Node<string> first = new Node<string>("a");
            Node<string> second = new Node<string>("b");
            Node<string> newNode = new Node<string>(null);
            list.AddFirst(second);
            list.AddFirst(first);
            list.AddBefore(first, newNode);
            Assert.True(list.First == newNode && list.Last == second);
        }

        [Fact]
        public void AddBeforeMethodShouldNotThrowAnExceptionIfNewNodeIsObjectTypeAndNull()
        {
            var list = new LinkedList<object>();
            Node<object> first = new Node<object>("a");
            Node<object> second = new Node<object>(1);
            Node<object> newNode = new Node<object>(null);
            list.AddFirst(second);
            list.AddFirst(first);
            list.AddBefore(first, newNode);
            Assert.True(list.First == newNode && list.Last == second);
        }

        [Fact]
        public void AddMethodShouldAddTheItemAtTheEndOfTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Data == 3);
        }

        [Fact]
        public void ClearShouldEmptyTheListAndResetCount()
        {
            var list = new LinkedList<int>() { 1, 2 };
            list.Clear();
            Assert.True(list.Count == 0 && list.First == null
                && list.Sentinel.Next == list.Sentinel && list.Sentinel.Previous == list.Sentinel);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsInTheList()
        {
            var list = new LinkedList<int>() { 1, 2, 3 };
            Assert.True(list.Contains(2));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotInTheList()
        {
            var list = new LinkedList<int>() { 1, 2, 3 };
            Assert.False(list.Contains(4));
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElementAsValueFromTheList()
        {
            var list = new LinkedList<int>() { 1, 2, 4, 2 };
            Assert.True(list.Remove(2) && list.First.Data == 1
                && list.First.Next.Data == 4 && list.Last.Data == 2);
        }

        [Fact]
        public void RemoveMethodShouldRemoveGivenNodeFromList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> anotherSecond = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddLast(first);
            list.AddLast(second);
            list.AddLast(anotherSecond);
            list.AddLast(third);
            Assert.True(list.Remove(anotherSecond) && list.First == first
                && list.Last.Previous == second && list.Last == third);
        }

        [Fact]
        public void RemoveMethodShouldThrowAnExceptionIfTheNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            list.AddFirst(first);
            list.AddLast(second);
            Node<int> node = null;
            Assert.Throws<ArgumentNullException>(() => list.Remove(node));
        }

        [Fact]
        public void RemoveMethodShouldThrowAnExceptionIfTheNodeIsNotInTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddFirst(first);
            list.AddLast(second);
            Assert.Throws<InvalidOperationException>(() => list.Remove(third));
        }

        [Fact]
        public void CopyToMethodShouldCopyListElementsToArrayStartingAtGivenIndex()
        {
            var list = new LinkedList<int>() { 3, 4 };
            int[] array = new int[6];
            array[0] = 1;
            array[1] = 2;
            list.CopyTo(array, 2);
            Assert.True(array[0] == 1 && array[1] == 2 && array[2] == 3 && array[3] == 4);
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfArrayIsNull()
        {
            var list = new LinkedList<int>() { 1, 2 };
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfGivenArrayIndexIsLessThanZero()
        {
            var list = new LinkedList<int>() { 1, 2 };
            int[] array = new int[4];
            array[0] = 1;
            array[1] = 2;
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -2));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfGivenArrayDoesNotHaveEnoughEmptyPositions()
        {
            var list = new LinkedList<int>() { 1, 2, 3 };
            int[] array = new int[4];
            array[0] = 1;
            array[1] = 2;
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void RemoveFirstShouldRemoveFirstNodeFromTheList()
        {
            var list = new LinkedList<int>() { 1, 3, 4, 3 };
            Assert.True(list.RemoveFirst() && list.First.Data == 3
                && list.First.Previous == list.Sentinel && list.First.Next.Data == 4);
        }

        [Fact]
        public void RemoveFirstShouldThrowAnExceptionIfListIsEmpty()
        {
            var list = new LinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
        }

        [Fact]
        public void RemoveLastShouldRemoveLastNodeFromTheList()
        {
            var list = new LinkedList<int>() { 1, 3, 4, 3 };
            Assert.True(list.RemoveLast() && list.First.Previous == list.Sentinel
                && list.Last.Data == 4 && list.Last.Next == list.Sentinel);
        }

        [Fact]
        public void RemoveLastShouldThrowAnExceptionIfListIsEmpty()
        {
            var list = new LinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Fact]
        public void FindShouldReturnFirstNodeOccurenceOfTheGivenItem()
        {
            var list = new LinkedList<int>() { 1, 3, 4, 3 };
            Assert.True(list.Find(3) == list.First.Next);
        }

        [Fact]
        public void FindLastShouldReturnLastNodeOccurenceOfTheGivenItem()
        {
            var list = new LinkedList<int>() { 1, 3, 4, 3 };
            Assert.True(list.FindLast(3) == list.Last);
        }

        [Fact]
        public void FindLastShouldReturnLastNodeOccurenceOfTheGivenItemIfOnlyOneItemThatMatchesExistsInTheList()
        {
            var list = new LinkedList<int>() { 1, 3, 4 };
            Assert.True(list.FindLast(3) == list.First.Next);
        }

        [Fact]
        public void ListShouldBeDoublyLinkedList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            Node<int> fourth = new Node<int>(4);
            Node<int> fifth = new Node<int>(5);
            list.AddFirst(first);
            list.AddLast(fifth);
            list.AddAfter(first, second);
            list.AddBefore(fifth, fourth);
            list.AddAfter(second, third);
            Assert.True(list.First.Previous == list.Sentinel && list.Last.Next == list.Sentinel
                && list.Sentinel.Next == list.First && list.Sentinel.Previous == list.Last);
        }
    }
}
