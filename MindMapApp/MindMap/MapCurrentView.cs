using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class MapCurrentView : ApplicationViewCoordinates, ICurrentView
    {
        private readonly Map map;

        public MapCurrentView(Map map)
        {
            this.map = map;
            Left = DefaultMapLeft;
        }

        public int Top { get; set; } = 1;

        public int Left { get; set; }

        public void Print()
        {
            var tempTop = 1;
            for (int i = 0; i < map.FullMap.Count; i++)
            {
                if (i >= Top - 1 && i < (WindowHeight - 2) + Top - 2)
                {
                    Console.SetCursorPosition(OpenedMapsMenuWidth + 3, tempTop++);
                    Console.WriteLine(GetSubString(map.FullMap[i]));
                }
            }
        }

        public void MoveDown()
        {
            while (map.Current.Coordinates.top - Top >= WindowHeight - 2)
            {
                Top += 2;
            }
        }

        public void MoveUp()
        {
            if (map.Current.Coordinates.top >= Top)
            {
                return;
            }

            Top = map.Current.Coordinates.top;
        }

        public void MoveLeft()
        {
            if (map.Current.Coordinates.left - 3 >= Left)
            {
                return;
            }

            Left = map.Current == map.CentralNode
                ? OpenedMapsMenuWidth + 3
                : map.Current.Coordinates.left - 3;
        }

        public void MoveRight()
        {
            if ((map.Current.Coordinates.left - Left) + map.Current.Text.Length + 1
                < WindowWidth - OpenedMapsMenuWidth - 2)
            {
                return;
            }

            while (map.Current.Coordinates.left + map.Current.Text.Length - Left > 85)
            {
                Left += 3;
            }
        }

        private string GetSubString(string line)
        {
            var substring = line.Substring(Left - (OpenedMapsMenuWidth + 3) > line.Length
                ? line.Length
                : Left - (OpenedMapsMenuWidth + 3));
            if (substring.Contains('\u001b'))
            {
                return substring.Length - 10 > WindowWidth - 1 - (OpenedMapsMenuWidth + 3)
                    ? string.Concat(substring.Take(WindowWidth - 1 - (OpenedMapsMenuWidth + 3)))
                    : substring;
            }

            return substring.Length > WindowWidth - 1 - (OpenedMapsMenuWidth + 3)
                ? string.Concat(substring.Take(WindowWidth - 1 - (OpenedMapsMenuWidth + 3)))
                : substring;
        }
    }
}
