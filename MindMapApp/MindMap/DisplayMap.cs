using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class DisplayMap
    {
        private readonly Map map;

        public DisplayMap(Map map)
        {
            this.map = map;
        }

        public void Print(Node node, string indent = "   ")
        {
            if (node == map.CentralNode)
            {
                PrintNode(node, map.CentralNode.Collapsed ? "+" : "-");
            }

            for (int i = 0; i < node.Childs.Count && !node.Collapsed; i++)
            {
                PrintNode(node.Childs[i], indent);

                if (node.Childs[i].Childs.Count > 0)
                {
                    var last = node.Childs[i] == node.Childs.Last();
                    Print(node.Childs[i], indent + (last ? "   " : "|  "));
                }
            }
        }

        private void PrintNode(Node node, string indent)
        {
            if (node == map.CentralNode)
            {
                Console.WriteLine(map.Current == map.CentralNode
                ? $"\u001b[48;5;{4}m{indent + map.CentralNode.Text}\u001b[0m"
                : indent + map.CentralNode.Text);
            }
            else
            {
                string collapsedNodeIndent = node.Collapsed ? indent + "+--" : indent + "|--";
                Console.WriteLine(indent + "|");
                Console.WriteLine(map.Current == node
                    ? collapsedNodeIndent + $"\u001b[48;5;{4}m{node.Text}\u001b[0m"
                    : collapsedNodeIndent + node.Text);
            }
        }
    }
}
