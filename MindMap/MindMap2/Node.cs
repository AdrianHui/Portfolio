using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class Node
    {
        public Node(string text = "new node")
        {
            Text = text;
            Childs = new List<Node>();
        }

        public string Text { get; private set; }

        public Node Parent { get; set; }

        public List<Node> Childs { get; }

        public void ChangeNodeText(ConsoleKeyInfo key)
        {
            const int low = 31;
            const int high = 127;
            Text = key.KeyChar switch
            {
                '\b' => Text.Substring(0, Text.Length - 1),
                var x when x > low && x < high => Text + x,
                _ => Text
            };
        }
    }
}