using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class CurrentView
    {
        private readonly Map map;

        public CurrentView(Map map)
        {
            this.map = map;
        }

        public int Top { get; set; }

        public int Left { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public void Print()
        {
            for (int i = 0; i < map.FullMap.Count; i++)
            {
                if (i >= Top && i < (Height - map.HelpMenuHeight - 1) + Top)
                {
                    Console.WriteLine(map.FullMap[i].Substring(Left));
                }
            }
        }

        public void MoveDown()
        {
            if (Top == map.CentralNode.Coordinates.top
                && map.Current.Coordinates.top - Top > Height - map.HelpMenuHeight)
            {
                Top += 2;
                return;
            }

            var nodeAbove = map.GetNodeAbove(map.Current);
            if (nodeAbove.Coordinates.top + 2
                <= Top + Height - map.HelpMenuHeight - 1)
            {
                return;
            }

            while (nodeAbove.Coordinates.top + 2
                > Top + (Height - map.HelpMenuHeight - 1))
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
                ? 0
                : map.Current.Coordinates.left - 3;
        }

        public void MoveRight()
        {
            if ((map.Current.Coordinates.left - map.CurrentView.Left) + map.Current.Text.Length
                < Width)
            {
                return;
            }

            Left += map.Current.Coordinates.left - Left + map.Current.Text.Length - Width + 1;
        }
    }
}
