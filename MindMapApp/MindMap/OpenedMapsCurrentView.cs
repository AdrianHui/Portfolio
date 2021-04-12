using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    class OpenedMapsCurrentView : ApplicationViewCoordinates, ICurrentView
    {
        private readonly OpenedMaps openedMaps;

        public OpenedMapsCurrentView(OpenedMaps openedMaps)
        {
            this.openedMaps = openedMaps;
        }

        public int Top { get; set; }

        public int Left { get; set; } = 1;

        public void Print()
        {
            var mapsTop = 1;
            foreach (var map in openedMaps.Maps)
            {
                string mapTitle = map.Title.Length + 2 - (openedMaps.CurrentView.Left - 1) >= OpenedMapsMenuWidth
                    ? map.Title.Substring(openedMaps.CurrentView.Left - 1, OpenedMapsMenuWidth - 2)
                    : map.Title;
                if (openedMaps.Maps.IndexOf(map) + 1 > openedMaps.CurrentView.Top
                    && openedMaps.Maps.IndexOf(map) - openedMaps.CurrentView.Top < OpenedMapsMenuHeight - 1)
                {
                    Console.SetCursorPosition(1, mapsTop++);
                    Console.WriteLine(map == openedMaps.CurrentMap
                        ? $"\u001b[33m{mapTitle}\u001b[0m"
                        : mapTitle);
                }
            }
        }

        public void MoveDown()
        {
            if (openedMaps.Maps.IndexOf(openedMaps.CurrentMap) - Top < OpenedMapsMenuHeight - 1)
            {
                return;
            }

            Top++;
        }

        public void MoveLeft()
        {
            if (Left == 1)
            {
                return;
            }

            Left--;
        }

        public void MoveRight()
        {
            if (openedMaps.CurrentMap.Title.Length + 1 - (Left - 1) < OpenedMapsMenuWidth)
            {
                return;
            }

            Left++;
        }

        public void MoveUp()
        {
            if (Top == 0
                || (openedMaps.Maps.IndexOf(openedMaps.CurrentMap) - Top < WindowHeight
                && openedMaps.Maps.IndexOf(openedMaps.CurrentMap) + 1 != Top))
            {
                return;
            }

            Top--;
        }
    }
}
