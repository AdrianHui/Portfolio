using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class Map
    {
        public Map()
        {
            Current = CentralNode;
            CentralNode.Coordinates = (0, 0);
            CurrentView = new CurrentView(this);
        }

        public IList<string> FullMap { get; private set; }

        public CurrentView CurrentView { get; set; }

        internal Node CentralNode { get; } = new Node("central node");

        internal Node Current { get; set; }

        internal int HelpMenuHeight { get; } = 14;

        public void PrintMindMap()
        {
            FullMap = new List<string>();
            Build(CentralNode);
            CurrentView.Print();
            Console.SetCursorPosition(0, CurrentView.Height - HelpMenuHeight + 1);
            Console.WriteLine(HelpMenu());
            Console.SetCursorPosition(
                Current.Coordinates.left + Current.Text.Length - CurrentView.Left,
                Current.Coordinates.top - CurrentView.Top);
        }

        public void Edit(ConsoleKeyInfo currentKey)
        {
            switch (currentKey.Key)
            {
                case ConsoleKey.Insert:
                    new Control(this).Insert();
                    break;
                case ConsoleKey.Enter:
                    new Control(this).Enter();
                    break;
                case ConsoleKey.Delete:
                    new Control(this).Delete();
                    break;
                case ConsoleKey.Backspace:
                    new Control(this).Backspace();
                    break;
                case ConsoleKey.UpArrow:
                    new Control(this).UpArrow();
                    break;
                case ConsoleKey.DownArrow:
                    new Control(this).DownArrow();
                    break;
                case ConsoleKey.LeftArrow:
                    new Control(this).LeftArrow();
                    break;
                case ConsoleKey.RightArrow:
                    new Control(this).RightArrow();
                    break;
                default:
                    new Control(this).ChangeNodeText(currentKey.KeyChar);
                    break;
            }
        }

        internal Node GetNodeAbove(Node node)
        {
            if (node == CentralNode)
            {
                return node;
            }

            var index = Current.Siblings.IndexOf(Current);
            var temp = index == 0 ? node.Parent : node.Siblings[index - 1];
            if (index != 0 && Current.Siblings[index - 1].Childs.Count > 0)
            {
                while (temp.Childs.Count != 0 && !temp.Collapsed)
                {
                    temp = temp.Childs.Last();
                }
            }

            return temp;
        }

        private void Build(Node node, string indent = "   ")
        {
            if (node == CentralNode)
            {
                AddNode(node, indent);
            }

            for (int i = 0; i < node.Childs.Count && !node.Collapsed; i++)
            {
                AddNode(node.Childs[i], indent);
                if (node.Childs[i].Childs.Count > 0)
                {
                    var last = node.Childs[i] == node.Childs.Last();
                    Build(node.Childs[i], indent + (last ? "   " : "|  "));
                }
            }
        }

        private void AddNode(Node node, string indent)
        {
            string nodeText = node == Current
                                       ? $"\u001b[48;5;{4}m{node.Text}\u001b[0m"
                                       : node.Text;
            string collapsedNodeIndent = indent + (node.Collapsed ? "+--" : "|--");
            if (node == CentralNode)
            {
                FullMap.Add((node.Collapsed ? "+" : "-") + nodeText);
            }
            else
            {
                FullMap.Add(indent + "|");
                FullMap.Add(collapsedNodeIndent + nodeText);
            }

            node.Coordinates = node == CentralNode
                    ? (0, 0)
                    : (collapsedNodeIndent.Length, FullMap.Count - 1);
        }

        private string HelpMenu()
        {
            string[] elements =
            {
                " Shortcut Keys:",
                "  - Esc - stops the application.",
                "  - Insert - adds new child node.",
                "  - Enter - adds new sibling node.",
                "  - Delete - deletes current node.",
                "  - Backspace - erases last character from node's name.",
                "  - RightArrow -  expands the node or changes selection to current node's first child node.",
                "  - LeftArrow - collapses the node or changes selection to current node's parent.",
                "  - DownArrow - changes selection to node below the current node.",
                "  - UpArrow - changes selection to node above the current node."
            };
            var maxLength = elements.Max(x => x.Length);
            var helpBox = elements.Select(x => x.PadRight(maxLength, ' '))
                                    .Select(x => $"\u001b[48;5;{17}m{"*" + x + "*"}\u001b[0m");
            var border = $"\u001b[48;5;{17}m{"".PadRight(maxLength + 2, '*')}\u001b[0m";
            return $"{border}\n{string.Join('\n', helpBox)}\n{border}";
        }
    }
}