using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    public class ApplicationViewCoordinates
    {
        public ApplicationViewCoordinates()
        {
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            OpenedMapsMenuWidth = WindowWidth / 4;
            OpenedMapsMenuHeight = WindowHeight - 12;
            DefaultMapLeft = OpenedMapsMenuWidth + 3;
        }

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        public int OpenedMapsMenuWidth { get; set; }

        public int OpenedMapsMenuHeight { get; set; }

        public int DefaultMapLeft { get; set; }
    }
}
