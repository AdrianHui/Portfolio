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
            while (true)
            {
                Console.Clear();
                map.DisplayNodes();
                map.ReadKey();
            }
        }
    }
}