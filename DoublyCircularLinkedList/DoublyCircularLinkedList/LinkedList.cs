using System;
using System.Collections;
using System.Collections.Generic;

namespace DoublyCircularLinkedList
{
    class LinkedList<T> : ICollection<T>
    {
        public Node<T> First;
        public Node<T> Last;
        public Node<T> Current;

        public LinkedList()
        {
            First = null;
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
            if (First == null)
            {
                First = newNode;
                Last = newNode;
                First.Next = Last;
                First.Previous = Last;
                Last.Next = First;
                Last.Previous = First;
            }
            else
            {
                newNode.Next = First;
                newNode.Previous = Last;
                First.Previous = newNode;
                Last.Next = newNode;
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
            if (First == null)
            {
                AddFirst(newNode);
            }
            else
            {
                newNode.Next = First;
                newNode.Previous = Last;
                First.Previous = newNode;
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
            if (node == null)
            {
                throw new ArgumentNullException("node", "The node is null.");
            }
            else if (Find(node.Data) == null)
            {
                throw new InvalidOperationException("The node you provided could not be found.");
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
            AddAfter(node.Previous, newNode);
        }

        public void Clear()
        {
            Count = 0;
            First.Next = null;
            First.Previous = null;
            First = null;
            Last.Next = null;
            Last.Previous = null;
            Last = null;
        }

        public bool Contains(T item)
        {
            Current = Search(item, First);
            if (Current == null)
            {
                return false;
            }

            return Current.Data.Equals(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Current = First;
            while (!Current.Equals(Last))
            {
                array[arrayIndex] = Current.Data;
                Current = Current.Next;
                arrayIndex++;
            }

            array[arrayIndex] = Current.Data;
        }

        public bool Remove(T item)
        {
            Current = Search(item, First);
            if (Current == First)
            {
                First = First.Next;
            }
            else if (!Current.Data.Equals(item))
            {
                return false;
            }

            Current.Previous.Next = Current.Next;
            Current.Next.Previous = Current.Previous;
            Count--;
            return true;
        }

        public bool Remove(Node<T> node)
        {
            return Remove(node.Data);
        }

        public bool RemoveFirst()
        {
            if (First == null)
            {
                return false;
            }

            Last.Next = First.Next;
            First = First.Next;
            First.Previous = Last;
            Count--;
            return true;
        }

        public bool RemoveLast()
        {
            if (Last == null)
            {
                return false;
            }

            Last.Previous.Next = First;
            Last = Last.Previous;
            First.Previous = Last;
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
            Current = First;
            while (!Current.Equals(Last))
            {
                yield return Current.Data;
                Current = Current.Next;
            }

            yield return Last.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private Node<T> Search(T item, Node<T> searchStartPoint)
        {
            Current = searchStartPoint;
            Node<T> end = searchStartPoint == First ? Last : First;
            while (!Current.Data.Equals(item) && !Current.Equals(end))
            {
                Current = searchStartPoint == First ? Current.Next : Current.Previous;
            }

            return Current.Data.Equals(item) ? Current : null;
        }
    }
}
