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
            list.AddFirst(new Node<int>(4));
            list.AddFirst(new Node<int>(3));
            list.AddFirst(new Node<int>(2));
            list.AddFirst(new Node<int>(1));
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Previous.Data == 3 && list.Last.Data == 4);
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
            list.AddLast(new Node<int>(1));
            list.AddLast(new Node<int>(2));
            list.AddLast(new Node<int>(3));
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Data == 3);
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
            list.AddFirst(4);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddBefore(list.Last, new Node<int>(3));
            Assert.True(list.First.Next.Next.Data == 3);
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
            list.AddFirst(1);
            list.AddFirst(2);
            list.Clear();
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfElementIsInTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(5);
            Assert.True(list.Contains(5));
        }

        [Fact]
        public void ContainsShouldReturnFalseIfElementIsNotInTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            list.Add(5);
            Assert.False(list.Contains(3));
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
