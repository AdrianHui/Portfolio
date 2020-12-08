using System;
using Xunit;

namespace DoublyCircularLinkedList.Facts
{
    public class LinkedListFacts
    {
        [Fact]
        public void CountShouldReturnNumberOfElementsInList()
        {
            var list = new LinkedList<int>();
            list.Add(2);
            list.Add(4);
            list.Add(6);
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
            list.AddFirst(4);
            list.AddFirst(3);
            list.AddFirst(2);
            list.AddFirst(1);
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Previous.Data == 3 && list.Last.Data == 4);
        }

        [Fact]
        public void AddFirstMethodShouldAddElementsAsNodesAtTheBeginingOfTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(third);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.True(list.First == first && list.First.Next == second
                && list.Last.Previous == third && list.Last == fourth);
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
            Node<int> second = new Node<int>(2);
            first.Next = second;
            first.Previous = second;
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
            Node<int> second = new Node<int>(2);
            first.Next = second;
            first.Previous = second;
            Assert.Throws<InvalidOperationException>(() => list.AddLast(first));
        }

        [Fact]
        public void AddAfterMethodShouldAddElementsAsValueAfterGivenNode()
        {
            var list = new LinkedList<int>();
            list.AddFirst(4);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddAfter(list.First.Next, 3);
            Assert.True(list.First.Next.Data == 2 && list.Last.Previous.Data == 3
                && list.Last.Data == 4);
        }

        [Fact]
        public void AddAfterMethodShouldAddElementsAsNodesAfterGivenNode()
        {
            var list = new LinkedList<int>();
            list.AddFirst(4);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddAfter(list.First.Next, new Node<int>(3));
            Assert.True(list.First.Next.Data == 2 && list.Last.Previous.Data == 3
                && list.Last.Data == 4);
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Node<int> node = null;
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(node, third));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Node<int> newNode = null;
            Assert.Throws<ArgumentNullException>(() => list.AddAfter(second, newNode));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNodeCannotBeFoundInCurrentList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            Node<int> fifth = new Node<int>(5);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddAfter(fifth, new Node<int>(3)));
        }

        [Fact]
        public void AddAfterMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            Node<int> newNode = new Node<int>(3);
            Node<int> node = new Node<int>(4);
            newNode.Next = node;
            newNode.Previous = node;
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddAfter(second, newNode));
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
            var list = new LinkedList<int>();
            list.AddFirst(4);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddBefore(list.Last, 3);
            Assert.True(list.First.Next.Next.Data == 3);
        }

        [Fact]
        public void AddBeforeMethodShouldAddElementAsNodeBeforeGivenNode()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            list.AddBefore(list.Last, third);
            Assert.True(list.First.Next.Next == third);
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Node<int> node = null;
            Assert.Throws<ArgumentNullException>(() => list.AddBefore(node, third));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNewNodeIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Node<int> newNode = null;
            Assert.Throws<ArgumentNullException>(() => list.AddBefore(second, newNode));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNodeCannotBeFoundInCurrentList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            Node<int> fifth = new Node<int>(5);
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddBefore(fifth, new Node<int>(3)));
        }

        [Fact]
        public void AddBeforeMethodShouldThrowAnExceptionIfNewNodeBelongsToAnotherList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> fourth = new Node<int>(4);
            Node<int> newNode = new Node<int>(3);
            Node<int> node = new Node<int>(4);
            newNode.Next = node;
            newNode.Previous = node;
            list.AddFirst(fourth);
            list.AddFirst(second);
            list.AddFirst(first);
            Assert.Throws<InvalidOperationException>(() => list.AddBefore(fourth, newNode));
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
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            list.AddFirst(first);
            list.AddFirst(second);
            list.Clear();
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsInTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddLast(first);
            list.AddLast(second);
            list.AddLast(third);
            Assert.True(list.Contains(2));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotInTheList()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddLast(first);
            list.AddLast(second);
            list.AddLast(third);
            Assert.False(list.Contains(4));
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElementAsValueFromTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(2);
            Assert.True(list.Remove(2) && list.First.Data == 1
                && list.First.Next.Data == 4 && list.Last.Data == 2);
        }

        [Fact]
        public void RemoveMethodShouldRemoveFirstOccurenceOfGivenElementAsNodeFromTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(2);
            Assert.True(list.Remove(new Node<int>(2)) && list.First.Data == 1
                && list.First.Next.Data == 4 && list.Last.Data == 2);
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
            var list = new LinkedList<int>();
            list.Add(3);
            list.Add(4);
            int[] array = new int[4];
            array[0] = 1;
            array[1] = 2;
            list.CopyTo(array, 2);
            Assert.True(array[0] == 1 && array[1] == 2 && array[2] == 3 && array[3] == 4);
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfArrayIsNull()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            list.AddFirst(first);
            list.AddLast(second);
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfGivenArrayIndexIsLessThanZero()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            list.AddFirst(first);
            list.AddLast(second);
            int[] array = new int[4];
            array[0] = 1;
            array[1] = 2;
            Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(array, -2));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfGivenArrayDoesNotHaveEnoughEmptyPositions()
        {
            var list = new LinkedList<int>();
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);
            Node<int> third = new Node<int>(3);
            list.AddFirst(first);
            list.AddLast(second);
            list.AddLast(third);
            int[] array = new int[4];
            array[0] = 1;
            array[1] = 2;
            Assert.Throws<ArgumentException>(() => list.CopyTo(array, 2));
        }

        [Fact]
        public void RemoveFirstShouldRemoveFirstNodeFromTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(3);
            Assert.True(list.RemoveFirst() && list.First.Data == 3
                && list.First.Previous.Data == 3 && list.First.Next.Data == 4);
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
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(3);
            Assert.True(list.RemoveLast() && list.First.Previous.Data == 4
                && list.Last.Data == 4 && list.Last.Next.Data == 1);
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
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(3);
            Assert.True(list.Find(3) == list.First.Next);
        }

        [Fact]
        public void FindLastShouldReturnLastNodeOccurenceOfTheGivenItem()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            list.Add(3);
            Assert.True(list.FindLast(3) == list.Last);
        }

        [Fact]
        public void FindLastShouldReturnLastNodeOccurenceOfTheGivenItemIfOnlyOneItemThatMatchesExistsInTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(3);
            list.Add(4);
            Assert.True(list.FindLast(3) == list.First.Next);
        }

        [Fact]
        public void ListShouldBeDoublyLinkedList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Assert.True(list.First.Previous == list.Last && list.Last.Next == list.First
                && list.First.Next == list.Last.Previous);
        }
    }
}
