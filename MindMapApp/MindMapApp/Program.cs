using MindMap;
using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.Clear();
                map.PrintMindMap();
                key = Console.ReadKey();
                map.Edit(key);
            }
        }
    }
}