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
            var centralNode = new Node();
            while (true)
            {
                Console.Clear();
                centralNode.DisplayNode();
                centralNode.ChangeNodeText();
            }
        }
    }
}