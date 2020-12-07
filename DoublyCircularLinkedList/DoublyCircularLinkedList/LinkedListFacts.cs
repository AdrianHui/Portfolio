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
        public void AddFirstMethodShouldAddTheItemAtTheBeginingOfTheList()
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
        public void AddLastMethodShouldAddTheItemAsFirstAndLastElementIfListIsEmpty()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            Assert.True(list.First.Data == 1 && list.Last.Data == 1);
        }

        [Fact]
        public void AddLastMethodShouldAddTheItemAtTheendOfTheList()
        {
            var list = new LinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            Assert.True(list.First.Data == 1 && list.First.Next.Data == 2
                && list.Last.Data == 3);
        }

        [Fact]
        public void AddAfterMethodShouldAddTheItemAfterGivenNode()
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
        public void AddBeforeMethodShouldAddTheItemBeforeGivenNode()
        {
            var list = new LinkedList<int>();
            list.AddFirst(4);
            list.AddFirst(2);
            list.AddFirst(1);
            list.AddBefore(list.Last, 3);
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
        public void ClearShouldResetElementsCount()
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
        public void RemoveMethodShouldRemoveGivenElementFromTheList()
        {
            var list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(4);
            Assert.True(list.Remove(2) && list.First.Data == 1 && list.Last.Data == 4);
        }
    }
}
