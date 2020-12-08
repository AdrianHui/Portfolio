using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyCircularLinkedList
{
    class LinkedList<T> : ICollection<T>
    {
        public Node<T> First;
        public Node<T> Last;
        public Node<T> Sentinel;
        private Node<T> current;

        public LinkedList()
        {
            Sentinel = new Node<T>(default(T));
            Sentinel.Next = Sentinel;
            Sentinel.Previous = Sentinel;
        }

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
            CheckIfIsAValidNode(newNode);
            CheckIfBelongsToAnotherList(newNode);
            if (First == null)
            {
                First = newNode;
                Last = newNode;
                First.Next = Last;
                Last.Previous = First;
                First.Previous = Sentinel;
                Last.Next = Sentinel;
                Sentinel.Next = First;
                Sentinel.Previous = Last;
            }
            else
            {
                newNode.Next = First;
                newNode.Previous = Sentinel;
                First.Previous = newNode;
                Last.Next = Sentinel;
                First = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            AddLast(new Node<T>(item));
        }

        public void AddLast(Node<T> newNode)
        {
            CheckIfIsAValidNode(newNode);
            CheckIfBelongsToAnotherList(newNode);
            if (First == null)
            {
                AddFirst(newNode);
            }
            else
            {
                newNode.Next = Sentinel;
                newNode.Previous = Last;
                Sentinel.Previous = newNode;
                Last.Next = newNode;
                Last = newNode;
                Count++;
            }
        }

        public void AddAfter(Node<T> node, T item)
        {
            AddAfter(node, new Node<T>(item));
        }

        public void AddAfter(Node<T> node, Node<T> newNode)
        {
            CheckIfIsAValidNode(node);
            CheckIfIsAValidNode(newNode);
            CheckIfBelongsToAnotherList(newNode);
            CheckIfElementIsInList(node);
            if (node == Last)
            {
                AddLast(newNode);
                return;
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
            CheckIfIsAValidNode(newNode);
            CheckIfBelongsToAnotherList(newNode);
            CheckIfElementIsInList(node);
            if (node == First)
            {
                AddFirst(newNode);
                return;
            }

            AddAfter(node.Previous, newNode);
        }

        public void Clear()
        {
            Count = 0;
            Sentinel.Next = null;
            Sentinel.Previous = null;
            First.Next = null;
            First.Previous = null;
            First = null;
            Last.Next = null;
            Last.Previous = null;
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
                throw new ArgumentOutOfRangeException("arrayIndex", "Index was outside the bounds of the array.");
            }
            else if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("There is not enough space in destination array.");
            }

            current = First;
            while (!current.Equals(Sentinel))
            {
                array[arrayIndex] = current.Data;
                current = current.Next;
                arrayIndex++;
            }
        }

        public bool Remove(T item)
        {
            return Remove(new Node<T>(item));
        }

        public bool Remove(Node<T> node)
        {
            CheckIfIsAValidNode(node);
            CheckIfElementIsInList(node);
            current = Search(node.Data, First);
            if (current == First)
            {
                First = First.Next;
            }
            else if (!current.Data.Equals(node.Data))
            {
                return false;
            }

            current.Previous.Next = current.Next;
            current.Next.Previous = current.Previous;
            Count--;
            return true;
        }

        public bool RemoveFirst()
        {
            if (First == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            Sentinel.Next = First.Next;
            First = First.Next;
            First.Previous = Sentinel;
            Count--;
            return true;
        }

        public bool RemoveLast()
        {
            if (Last == null)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            Last.Previous.Next = Sentinel;
            Last = Last.Previous;
            Sentinel.Previous = Last;
            Count--;
            return true;
        }

        public Node<T> Find(T item)
        {
            return Search(item, First);
        }

        public Node<T> FindLast(T item)
        {
            return Search(item, Last);
        }

        public IEnumerator<T> GetEnumerator()
        {
            current = First;
            while (!current.Equals(Sentinel))
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> Search(T item, Node<T> searchStartPoint)
        {
            current = searchStartPoint;
            while (!current.Data.Equals(item) && !current.Equals(Sentinel))
            {
                current = searchStartPoint == First ? current.Next : current.Previous;
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
            if (Find(node.Data) != null)
            {
                return;
            }

            throw new InvalidOperationException("The node you provided could not be found.");
        }
    }
}
