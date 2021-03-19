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

        public (int left, int top) Coordinates { get; set; } = (-1, -1);

        public string Text { get; set; }

        public Node Parent { get; set; }

        public IList<Node> Childs { get; }

        public IList<Node> Siblings { get; set; }

        public bool Collapsed { get; set; }
    }
}