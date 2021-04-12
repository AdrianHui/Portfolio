using MindMap;
using System;
using System.Collections.Generic;

namespace MindMapApp
{
    class Program
    {
        static void Main()
        {
            var coord = new ApplicationViewCoordinates();
            var mindMaps = new MindMaps();
            while (true)
            {
                coord.WindowWidth = Console.WindowWidth;
                coord.WindowHeight = Console.WindowHeight;
                Console.Clear();
                mindMaps.Print();
                mindMaps.Edit(Console.ReadKey());
            }
        }
    }
}