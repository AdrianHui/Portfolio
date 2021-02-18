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
            new DisplayMap(this).Print(CentralNode);
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
    }
}
