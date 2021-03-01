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

        public int LeftCoord { get; set; }

        public int TopCoord { get; set; }

        public string Text { get; set; }

        public Node Parent { get; set; }

        public IList<Node> Childs { get; }

        public IList<Node> Siblings { get; set; }

        public bool Collapsed { get; set; }
    }
}