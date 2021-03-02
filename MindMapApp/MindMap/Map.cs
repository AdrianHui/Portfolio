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
        }

        internal Node CentralNode { get; } = new Node("central node");

        internal Node Current { get; set; }

        public void PrintMindMap()
        {
            new DisplayMap(this).PrintMap(CentralNode);
            Console.WriteLine("\n\n" + HelpMenu());
            Console.SetCursorPosition(Current.LeftCoord, Current.TopCoord);
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
