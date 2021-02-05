using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class Map
    {
        public Map()
        {
            AllNodes = new List<Node>() { new Node("central node") };
            Current = AllNodes.First();
        }

        internal Node Current { get; set; }

        internal List<Node> AllNodes { get; set; }

        public void DisplayNodes()
        {
            foreach (var node in AllNodes)
            {
                Console.WriteLine(Current.Equals(node)
                                  ? $"\u001b[48;5;{243}m{WrapText(node.Text)}\u001b[0m"
                                  : WrapText(node.Text));
            }
        }

        public void ReadKey()
        {
            var currentKey = Console.ReadKey();
            switch (currentKey.Key)
            {
                case ConsoleKey.Insert:
                    AddChild();
                    break;
                case ConsoleKey.UpArrow:
                    Current = Current.Parent == null ? Current : Current.Parent;
                    break;
                case ConsoleKey.DownArrow:
                    Current = Current.Childs.Count == 0 ? Current : Current.Childs.First();
                    break;
                default:
                    Current.ChangeNodeText(currentKey);
                    break;
            }
        }

        private void AddChild()
        {
            Node newNode = new Node();
            newNode.Parent = Current;
            AllNodes.Add(newNode);
            Current.Childs.Add(newNode);
            Current = newNode;
        }

        private string WrapText(string text)
        {
            return new string('-', text.Length + 2)
                   + "\n|" + text + "|\n"
                   + new string('-', text.Length + 2);
        }
    }
}
