using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class MapCurrentView : ICurrentView
    {
        private readonly Map map;

        public MapCurrentView(Map map)
        {
            this.map = map;
        }

        public (int Width, int Height) Window { get; set; }

        public int Top { get; set; } = 1;

        public int Left { get; set; }

        public int CurrentViewWidth { get => Window.Width - (Window.Width / 4 + 3); }

        public int CurrentViewHeight { get => Window.Height - 2; }

        public void Print()
        {
            var tempTop = 1;
            for (int i = 0; i < map.FullMap.Count; i++)
            {
                if (i >= Top - 1 && i < CurrentViewHeight + Top - 2)
                {
                    Console.SetCursorPosition(Window.Width / 4 + 3, tempTop++);
                    Console.WriteLine(GetSubString(map.FullMap[i]));
                }
            }
        }

        public void MoveDown()
        {
            while (map.Current.Coordinates.top - Top >= CurrentViewHeight)
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
                ? Window.Width / 4 + 3
                : map.Current.Coordinates.left - 3;
        }

        public void MoveRight()
        {
            if ((map.Current.Coordinates.left - Left) + map.Current.Text.Length + 1
                < CurrentViewWidth)
            {
                return;
            }

            while (map.Current.Coordinates.left + map.Current.Text.Length - Left > CurrentViewWidth - 2)
            {
                Left += 3;
            }
        }

        private string GetSubString(string line)
        {
            var substring = line.Substring(Left - (Window.Width / 4 + 3) > line.Length
                ? line.Length
                : Left - (Window.Width / 4 + 3));
            if (substring.Contains('\u001b'))
            {
                return substring.Length - 10 > Window.Width - 1 - (Window.Width / 4 + 3)
                    ? string.Concat(substring.Take(Window.Width - 1 - (Window.Width / 4 + 3)))
                    : substring;
            }

            return substring.Length > Window.Width - 1 - (Window.Width / 4 + 3)
                ? string.Concat(substring.Take(Window.Width - 1 - (Window.Width / 4 + 3)))
                : substring;
        }
    }
}
