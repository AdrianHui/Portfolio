using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class OpenedMapsControl : IControl
    {
        private readonly OpenedMaps maps;

        public OpenedMapsControl(OpenedMaps maps)
        {
            this.maps = maps;
        }

        public void Backspace()
        {
            if (maps.CurrentMap.Title == "")
            {
                return;
            }

            maps.CurrentMap.Title =
                maps.CurrentMap.Title.Substring(0, maps.CurrentMap.Title.Length - 1);
            maps.CurrentView.MoveRight();
            maps.CurrentView.MoveLeft();
        }

        public void ChangeText(char character)
        {
            const int low = 31;
            const int high = 127;
            maps.CurrentMap.Title = character > low && character < high
                ? maps.CurrentMap.Title + character
                : maps.CurrentMap.Title;
            maps.CurrentView.MoveRight();
        }

        public void Delete()
        {
            if (maps.CurrentMap == maps.Maps.First())
            {
                if (maps.CurrentMap == maps.Maps.Last())
                {
                    return;
                }

                DownArrow();
                maps.Maps.RemoveAt(maps.Maps.IndexOf(maps.CurrentMap) - 1);
                return;
            }

            UpArrow();
            maps.Maps.RemoveAt(maps.Maps.IndexOf(maps.CurrentMap) + 1);
            maps.CurrentView.Left = maps.CurrentView.Left > 1
                ? maps.CurrentView.Left - 1
                : maps.CurrentView.Left;
        }

        public void DownArrow()
        {
            if (maps.CurrentMap == maps.Maps.Last())
            {
                return;
            }

            maps.CurrentView.Left = 1;
            maps.CurrentMap = maps.Maps[maps.Maps.IndexOf(maps.CurrentMap) + 1];
            maps.CurrentView.MoveDown();
        }

        public void Enter()
        {
        }

        public void Insert()
        {
            maps.Maps.Add(new Map());
            maps.CurrentMap = maps.Maps.Last();
            maps.CurrentView.MoveDown();
        }

        public void LeftArrow()
        {
            maps.CurrentView.MoveLeft();
        }

        public void RightArrow()
        {
            maps.CurrentView.MoveRight();
        }

        public void UpArrow()
        {
            if (maps.CurrentMap == maps.Maps.First())
            {
                return;
            }

            maps.CurrentMap = maps.Maps[maps.Maps.IndexOf(maps.CurrentMap) - 1];
            maps.CurrentView.MoveUp();
        }
    }
}
