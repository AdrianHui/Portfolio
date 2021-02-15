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
                case ConsoleKey.Delete:
                    DeleteNode();
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                    MoveUpAndDown(currentKey.Key);
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:
                    MoveRightAndLeft(currentKey.Key);
                    break;
                default:
                    Current.ChangeNodeText(currentKey);
                    break;
            }
        }

        private void DeleteNode()
        {
            if (Current == centralNode)
            {
                return;
            }

            var childIndex = Current.Parent.Childs.IndexOf(Current);
            bool last = childIndex == Current.Parent.Childs.Count - 1;
            Current.Parent.Childs.RemoveAt(childIndex);
            if (Current.Parent.Childs.Count == 0)
            {
                Current = Current.Parent;
            }
            else
            {
                Current = last
                        ? Current.Parent.Childs[childIndex - 1]
                        : Current.Parent.Childs[childIndex];
            }
        }

        private void MoveRightAndLeft(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
            {
                Current = Current.Parent ?? Current;
            }
            else
            {
                Current = Current.Childs.Count > 0 ? Current.Childs.First() : Current;
            }
        }

        private void MoveUpAndDown(ConsoleKey key)
        {
            if (Current == centralNode)
            {
                return;
            }

            var childIndex = Current.Parent.Childs.IndexOf(Current);
            if (key == ConsoleKey.UpArrow)
            {
                Current = childIndex == 0 ? Current : Current.Parent.Childs[childIndex - 1];
            }
            else
            {
                Current = Current.Parent.Childs[childIndex] == Current.Parent.Childs.Last()
                    ? Current
                    : Current.Parent.Childs[childIndex + 1];
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
