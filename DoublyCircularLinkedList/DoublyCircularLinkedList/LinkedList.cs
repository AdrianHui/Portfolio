using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyCircularLinkedList
{
    class LinkedList<T> : ICollection<T>
    {
        public Node<T> Sentinel;
        private Node<T> current;

        public LinkedList()
        {
            Sentinel = new Node<T>(default(T));
            Sentinel.Next = Sentinel;
            Sentinel.Previous = Sentinel;
        }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

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
            AddAfter(Sentinel, newNode);
        }

        public void AddLast(T item)
        {
            AddLast(new Node<T>(item));
        }

        public void AddLast(Node<T> newNode)
        {
            AddAfter(Sentinel.Previous, newNode);
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
            if (node == Last)
            {
                newNode.Next = Sentinel;
                newNode.Previous = Last;
                Sentinel.Previous = newNode;
                Last.Next = newNode;
                Last = newNode;
                First = Sentinel.Next;
                Count++;
                return;
            }
            else if (node == Sentinel)
            {
                First = newNode;
                Last ??= newNode;
            }

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
            Sentinel.Next = Sentinel;
            Sentinel.Previous = Sentinel;
            First = null;
            Last = null;
        }

        public bool Contains(T item)
        {
            current = Search(item, First);
            if (current == null)
            {
                return false;
            }

            return current.Data.Equals(item);
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

            for (current = First; current != Sentinel; current = current.Next)
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
            for (current = First; current != Sentinel; current = current.Next)
            {
                if (current == node)
                {
                    if (current == First)
                    {
                        First = First.Next;
                    }
                    else if (current == Last)
                    {
                        Last = Last.Previous;
                    }

                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                    Count--;
                    return true;
                }
            }

            return false;
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
            return Search(item, Sentinel.Next);
        }

        public Node<T> FindLast(T item)
        {
            return Search(item, Sentinel.Previous);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (current = First; current != Sentinel; current = current.Next)
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
            if (item == null)
            {
                return null;
            }

            for (current = searchStartPoint; current != Sentinel;
                current = searchStartPoint == Sentinel.Next
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
            if (node is object || node is string || node != null)
            {
                return;
            }

            throw new ArgumentNullException("node", "The node is null.");
        }

        private void CheckIfBelongsToAnotherList(Node<T> node)
        {
            if (node.Next == null && node.Previous == null)
            {
                return;
            }

            throw new InvalidOperationException(
                    "The node you provided belongs to another LinkedList.");
        }

        private void CheckIfElementIsInList(Node<T> node)
        {
            if (node == Sentinel || node is string
                || node.Data.GetType().Equals(typeof(object)) || Find(node.Data) != null)
            {
                return;
            }

            throw new InvalidOperationException("The node you provided could not be found.");
        }
    }
}
