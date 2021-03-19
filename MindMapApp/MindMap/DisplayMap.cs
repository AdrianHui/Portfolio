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
                PrintNode(node, indent);
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
            string nodeText = node == map.Current
                                       ? $"\u001b[48;5;{4}m{node.Text}\u001b[0m"
                                       : node.Text;
            if (map.DisplayedNodesCount == map.MaxNodesNumber
                || (node.Coordinates.top != -1 && node.Coordinates.top < map.FirstNode.Coordinates.top))
            {
                return;
            }
            else if (node == map.CentralNode)
            {
                Console.Write(node.Collapsed ? "+" : "-" + nodeText);
            }
            else
            {
                string collapsedNodeIndent = indent + (node.Collapsed ? "+--" : "|--");
                if (node != map.FirstNode)
                {
                    Console.Write("\n" + indent + "|");
                    Console.Write("\n" + collapsedNodeIndent + nodeText);
                }
                else
                {
                    Console.Write(collapsedNodeIndent + nodeText);
                }
            }

            map.DisplayedNodesCount++;
            SetCursorPosition(node);
            SetNodeCoordinates(node);
        }

        private void SetNodeCoordinates(Node node)
        {
            int topCoordinate = 0;
            if (node.Siblings != null && node != node.Siblings.First())
            {
                var temp = node.Siblings[node.Siblings.IndexOf(node) - 1];
                while (temp.Childs.Count != 0 && !temp.Collapsed)
                {
                    temp = temp.Childs.Last();
                }

                topCoordinate = temp.Coordinates.top + 2;
            }
            else if (node != map.CentralNode)
            {
                topCoordinate = node.Parent.Coordinates.top + 2;
            }

            node.Coordinates = (Console.CursorLeft, topCoordinate);
        }

        private void SetCursorPosition(Node node)
        {
            map.CursorPosition = node == map.Current
                ? (Console.CursorLeft, Console.CursorTop)
                : map.CursorPosition;
        }
    }
}
