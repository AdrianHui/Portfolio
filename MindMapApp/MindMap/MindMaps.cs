using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    public class MindMaps
    {
        public MindMaps()
        {
            OpenedMaps = new OpenedMaps();
            SelectedMenu = OpenedMaps;
        }

        public IMenu SelectedMenu { get; set; }

        public int WindowWidth { get; set; }

        public int WindowHeight { get; set; }

        internal OpenedMaps OpenedMaps { get; set; }

        public void Print()
        {
            OpenedMaps.CurrentMap.CurrentView.Window = (WindowWidth, WindowHeight);
            OpenedMaps.CurrentMap.CurrentView.Left =
                OpenedMaps.CurrentMap.CurrentView.Left > WindowWidth / 4 + 3
                ? OpenedMaps.CurrentMap.CurrentView.Left
                : WindowWidth / 4 + 3;
            OpenedMaps.CurrentView.Window = (WindowWidth, WindowHeight);
            new Borders(this).DrawBorders();
            PrintShortcutKeys();
            OpenedMaps.CurrentMap.FullMap = new List<string>();
            OpenedMaps.CurrentView.Print();
            OpenedMaps.CurrentMap.Build(OpenedMaps.CurrentMap.CentralNode);
            OpenedMaps.CurrentMap.CurrentView.Print();
            SetCursorPosition();
        }

        public void Edit(ConsoleKeyInfo currentKey)
        {
            IControl control = SelectedMenu.Control;

            switch (currentKey.Key)
            {
                case ConsoleKey.Insert:
                    control.Insert();
                    break;
                case ConsoleKey.Enter:
                    if (SelectedMenu is OpenedMaps)
                    {
                        SelectedMenu = OpenedMaps.CurrentMap;
                        control = new MapControl(OpenedMaps.CurrentMap);
                        control.Enter();
                        break;
                    }

                    control.Enter();
                    break;
                case ConsoleKey.Delete:
                    control.Delete();
                    break;
                case ConsoleKey.Backspace:
                    control.Backspace();
                    break;
                case ConsoleKey.UpArrow:
                    control.UpArrow();
                    break;
                case ConsoleKey.DownArrow:
                    control.DownArrow();
                    break;
                case ConsoleKey.LeftArrow:
                    control.LeftArrow();
                    break;
                case ConsoleKey.RightArrow:
                    control.RightArrow();
                    break;
                case ConsoleKey.Escape:
                    if (SelectedMenu is Map)
                    {
                        SelectedMenu = OpenedMaps;
                        control = new OpenedMapsControl(OpenedMaps);
                    }

                    control.LeftArrow();
                    break;
                default:
                    control.ChangeText(currentKey.KeyChar);
                    break;
            }
        }

        private void PrintShortcutKeys()
        {
            string[] elements =
            {
                "\u001b[33mInsert\u001b[0m - add new map",
                "       - add new child node",
                "\u001b[33mEnter\u001b[0m - open map",
                "      - add new sibling node",
                "\u001b[33mEsc\u001b[0m - exit map",
                "\u001b[33mDelete\u001b[0m - delete current node",
                "\u001b[33mBackspace\u001b[0m - erase character",
                "\u001b[33mArrows\u001b[0m - navigation"
            };
            var helpMentuTop = Console.WindowHeight - 10;
            for (int i = 0; i < elements.Length; i++)
            {
                Console.SetCursorPosition(1, helpMentuTop++);
                Console.WriteLine(elements[i]);
            }
        }

        private void SetCursorPosition()
        {
            if (SelectedMenu is OpenedMaps)
            {
                Console.SetCursorPosition(
                    OpenedMaps.CurrentMap.Title.Length + 1 >= Console.WindowWidth / 4
                    ? Console.WindowWidth / 4 - 1
                    : OpenedMaps.CurrentMap.Title.Length + 1 - (OpenedMaps.CurrentView.Left - 1),
                    OpenedMaps.Maps.IndexOf(OpenedMaps.CurrentMap) + 1 - OpenedMaps.CurrentView.Top);
            }
            else
            {
                Console.SetCursorPosition(
                    OpenedMaps.CurrentMap.Current.Coordinates.left + OpenedMaps.CurrentMap.Current.Text.Length
                        - OpenedMaps.CurrentMap.CurrentView.Left + Console.WindowWidth / 4 + 3,
                    OpenedMaps.CurrentMap.Current.Coordinates.top - OpenedMaps.CurrentMap.CurrentView.Top + 1);
            }
        }
    }
}
