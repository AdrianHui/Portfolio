using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class Map
    {
        readonly Node centralNode = new Node("central node");

        public Map()
        {
            Current = centralNode;
        }

        internal Node Current { get; set; }

        public void DisplayNodes(Node node = null, string indent = "\t")
        {
            node ??= centralNode;
            if (node == centralNode)
            {
                Console.WriteLine(Current == centralNode
                ? WrapText($"\u001b[48;5;{243}m{centralNode.Text}\u001b[0m")
                : WrapText(centralNode.Text));
            }

            for (int i = 0; i < node.Childs.Count; i++)
            {
                Console.WriteLine(indent + "|\n" + indent + "|");
                Console.WriteLine(Current == node.Childs[i]
                    ? indent + "|--" + WrapText($"\u001b[48;5;{243}m{node.Childs[i].Text}\u001b[0m")
                    : indent + "|--" + WrapText(node.Childs[i].Text));

                if (node.Childs[i].Childs.Count > 0)
                {
                    var last = node.Childs[i] == node.Childs.Last();
                    DisplayNodes(node.Childs[i], indent + (last ? "\t" : "|\t"));
                }
            }
        }

        public void ReadKey()
        {
            var currentKey = Console.ReadKey();
            switch (currentKey.Key)
            {
                case ConsoleKey.Insert:
                case ConsoleKey.Enter:
                    AddNode(currentKey.Key);
                    break;
                case ConsoleKey.UpArrow:
                    Current = Current.Parent.Childs[Current.Parent.Childs.IndexOf(Current) - 1];
                    break;
                case ConsoleKey.DownArrow:
                    Current = Current.Parent.Childs[Current.Parent.Childs.IndexOf(Current) + 1];
                    break;
                case ConsoleKey.LeftArrow:
                    Current = Current.Parent ?? Current;
                    break;
                case ConsoleKey.RightArrow:
                    Current = Current.Childs.Count > 0 ? Current.Childs.First() : Current;
                    break;
                default:
                    Current.ChangeNodeText(currentKey);
                    break;
            }
        }

        private void AddNode(ConsoleKey key)
        {
            Node newNode = new Node();
            if (key == ConsoleKey.Insert)
            {
                newNode.Parent = Current;
                Current.Childs.Add(newNode);
            }
            else
            {
                newNode.Parent = Current.Parent;
                Current.Parent.Childs.Add(newNode);
            }

            Current = newNode;
        }

        private string WrapText(string text)
        {
            return "(" + text + ")";
        }
    }
}
