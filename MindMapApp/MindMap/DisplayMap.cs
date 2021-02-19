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

        public void Print(Node node, string indent = "\t")
        {
            if (node == map.CentralNode)
            {
                Console.WriteLine(map.Current == map.CentralNode
                ? $"\u001b[48;5;{243}m{map.CentralNode.Text}\u001b[0m"
                : map.CentralNode.Text);
            }

            for (int i = 0; i < node.Childs.Count; i++)
            {
                Console.WriteLine(indent + "|");
                Console.WriteLine(map.Current == node.Childs[i]
                    ? indent + "|--" + $"\u001b[48;5;{243}m{node.Childs[i].Text}\u001b[0m"
                    : indent + "|--" + node.Childs[i].Text);

                if (node.Childs[i].Childs.Count > 0)
                {
                    var last = node.Childs[i] == node.Childs.Last();
                    Print(node.Childs[i], indent + (last ? "\t" : "|\t"));
                }
            }
        }
    }
}
