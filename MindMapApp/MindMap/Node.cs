using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class Node
    {
        public Node(string text)
        {
            Text = text;
            Childs = new List<Node>();
        }

        public string Text { get; set; }

        public Node Parent { get; set; }

        public IList<Node> Childs { get; }
    }
}