using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MindMap
{
    class Export
    {
        protected readonly Map map;

        public Export(Map map)
        {
            this.map = map;
        }

        public void ChooseLayout()
        {
            Console.Clear();
            Console.WriteLine("Please choose the layout:");
            Console.WriteLine("Root node top left corner - press 1.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.D1)
            {
                _ = new SaveFile(map.Title + ".html", new TopLeft(map.Title, map.CentralNode).GetFile(), "");
            }
            else if (key.Key == ConsoleKey.D2)
            {
                _ = 1;
            }
        }
    }
}
