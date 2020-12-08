using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyCircularLinkedList
{
    class Node<T>
    {
        public T Data;

        public Node(T data)
        {
            Data = data;
        }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}
