using MindMap;
using System;

namespace MindMapApp
{
    class Program
    {
        static void Main()
        {
            var mindMaps = new MindMaps();
            while (true)
            {
                mindMaps.WindowWidth = Console.WindowWidth;
                mindMaps.WindowHeight = Console.WindowHeight;
                Console.Clear();
                mindMaps.Print();
                mindMaps.Edit(Console.ReadKey());
            }
        }
    }
}