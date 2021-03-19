using MindMap;
using System;
using System.Collections.Generic;

namespace MindMapApp
{
    class Program
    {
        static void Main()
        {
            var map = new Map();
            ConsoleKeyInfo key = default;
            while (key.Key != ConsoleKey.Escape)
            {
                map.DisplayedNodesCount = 0;
                map.WindowSize = (Console.WindowHeight, Console.WindowWidth);
                map.MaxNodesNumber = (int)Math.Ceiling((decimal)(map.WindowSize.height - 15) / 2);
                Console.Clear();
                map.PrintMindMap();
                key = Console.ReadKey();
                map.Edit(key);
            }
        }
    }
}