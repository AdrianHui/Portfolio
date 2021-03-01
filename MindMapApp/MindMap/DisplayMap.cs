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

        public void PrintMap(Node node, string indent = "   ")
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
                    PrintMap(node.Childs[i], indent + (last ? "   " : "|  "));
                }
            }
        }

        private void PrintNode(Node node, string indent)
        {
            if (node == map.CentralNode)
            {
                Console.Write(indent + (map.Current == map.CentralNode
                                       ? $"\u001b[48;5;{4}m{map.CentralNode.Text}\u001b[0m"
                                       : map.CentralNode.Text));
            }
            else
            {
                string collapsedNodeIndent = indent + (node.Collapsed ? "+--" : "|--");
                Console.Write("\n" + indent + "|");
                Console.Write("\n" + (map.Current == node
                    ? collapsedNodeIndent + $"\u001b[48;5;{4}m{node.Text}\u001b[0m"
                    : collapsedNodeIndent + node.Text));
            }

            node.LeftCoord = Console.CursorLeft;
            node.TopCoord = Console.CursorTop;
        }
    }
}
