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
            if (First == null)
            {
                Current = new Node<T>(item);
                First = Current;
                Last = Current;
                First.Next = Last;
                First.Previous = Last;
                Last.Next = First;
                Last.Previous = First;
            }
            else
            {
                Current = new Node<T>(item);
                Current.Next = First;
                Current.Previous = Last;
                First.Previous = Current;
                Last.Next = Current;
                First = Current;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            if (First == null)
            {
                AddFirst(item);
            }
            else
            {
                Current = new Node<T>(item);
                Current.Next = First;
                Current.Previous = Last;
                First.Previous = Current;
                Last.Next = Current;
                Last = Current;
                Count++;
            }
        }

        public void AddAfter(Node<T> node, T item)
        {
            Current = new Node<T>(item);
            Current.Next = node.Next;
            Current.Next.Previous = Current;
            node.Next = Current;
            Current.Previous = node;
            Count++;
        }

        public void AddBefore(Node<T> node, T item)
        {
            AddAfter(node.Previous, item);
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            Current = First;
            while (!Current.Data.Equals(item) && !Current.Equals(Last))
            {
                Current = Current.Next;
            }

            return Current.Data.Equals(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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

        public bool Remove(T item)
        {
            Current = First;
            while (!Current.Data.Equals(item) && !Current.Equals(Last))
            {
                Current = Current.Next;
            }

            if (!Current.Data.Equals(item))
            {
                return false;
            }

            Current.Previous.Next = Current.Next;
            Current.Next.Previous = Current.Previous;
            Count--;
            return true;
        }
    }
}
