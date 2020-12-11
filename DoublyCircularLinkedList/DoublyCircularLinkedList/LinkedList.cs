using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyCircularLinkedList
{
    class LinkedList<T> : ICollection<T>
    {
        private readonly Node<T> sentinel;

        public LinkedList()
        {
            sentinel = new Node<T>(default(T));
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
            sentinel.AssociatedList = this;
        }

        public Node<T> First { get => sentinel.Next == sentinel ? null : sentinel.Next; }

        public Node<T> Last { get => sentinel.Previous == sentinel ? null : sentinel.Previous; }

        public int Count { get; private set; }

        public bool IsReadOnly { get; }

        public void Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T item)
        {
            AddFirst(new Node<T>(item));
        }

        public void AddFirst(Node<T> newNode)
        {
            AddAfter(sentinel, newNode);
        }

        public void AddLast(T item)
        {
            AddLast(new Node<T>(item));
        }

        public void AddLast(Node<T> newNode)
        {
            AddBefore(sentinel, newNode);
        }

        public void AddAfter(Node<T> node, T item)
        {
            AddAfter(node, new Node<T>(item));
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            CheckIfIsAValidNode(node);
            CheckIfElementIsInList(node);
            CheckIfIsAValidNode(newNode);
            CheckIfBelongsToAnotherList(newNode);
            newNode.AssociatedList = this;
            newNode.Next = node.Next;
            newNode.Next.Previous = newNode;
            node.Next = newNode;
            newNode.Previous = node;
            Count++;
        }

        public void AddBefore(Node<T> node, T item)
        {
            AddBefore(node, new Node<T>(item));
        }

        public void AddBefore(Node<T> node, Node<T> newNode)
        {
            CheckIfIsAValidNode(node);
            CheckIfElementIsInList(node);
            AddAfter(node.Previous, newNode);
        }

        public void Clear()
        {
            Count = 0;
            sentinel.Next = sentinel;
            sentinel.Previous = sentinel;
        }

        public bool Contains(T item)
        {
            return Search(item, sentinel.Next) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array", "Cannot be null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "arrayIndex", "Index was outside the bounds of the array.");
            }
            else if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("There is not enough space in destination array.");
            }

            for (var current = First; current != sentinel; current = current.Next)
            {
                array[arrayIndex] = current.Data;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            return Remove(Find(item));
        }

        public bool Remove(Node<T> node)
        {
            if (First == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            CheckIfIsAValidNode(node);
            CheckIfElementIsInList(node);
            node.Previous.Next = node.Next;
            node.Next.Previous = node.Previous;
            node.AssociatedList = null;
            Count--;
            return true;
        }

        public bool RemoveFirst()
        {
            return Remove(First);
        }

        public bool RemoveLast()
        {
            return Remove(Last);
        }

        public Node<T> Find(T item)
        {
            return Search(item, sentinel.Next);
        }

        public Node<T> FindLast(T item)
        {
            return Search(item, sentinel.Previous);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = sentinel.Next; current != sentinel; current = current.Next)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> Search(T item, Node<T> searchStartPoint)
        {
            Node<T> current;
            for (current = searchStartPoint; current != sentinel;
                current = searchStartPoint == sentinel.Next
                        ? current.Next : current.Previous)
            {
                if (current.Data.Equals(item))
                {
                    break;
                }
            }

            return current.Data.Equals(item) ? current : null;
        }

        private void CheckIfIsAValidNode(Node<T> node)
        {
            if (node != null)
            {
                return;
            }

            throw new ArgumentNullException("node", "The node is null.");
        }

        private void CheckIfBelongsToAnotherList(Node<T> node)
        {
            if (node.AssociatedList == null)
            {
                return;
            }

            throw new InvalidOperationException(
                    "The node you provided belongs to another LinkedList.");
        }

        private void CheckIfElementIsInList(Node<T> node)
        {
            if (node.AssociatedList == this)
            {
                return;
            }

            throw new InvalidOperationException("The node you provided could not be found.");
        }
    }
}
