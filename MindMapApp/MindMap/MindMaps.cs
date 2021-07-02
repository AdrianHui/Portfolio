using System;
using System.Collections.Generic;

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

        public int HelpMenuWidth { get => 30; }

        internal OpenedMaps OpenedMaps { get; set; }

        public void Print()
        {
            OpenedMaps.CurrentMap.CurrentView.Window = (WindowWidth, WindowHeight);
            OpenedMaps.CurrentView.Window = (WindowWidth, WindowHeight);
            OpenedMaps.CurrentMap.CurrentView.Left =
                OpenedMaps.CurrentMap.CurrentView.Left > HelpMenuWidth + 3
                ? OpenedMaps.CurrentMap.CurrentView.Left
                : HelpMenuWidth + 3;
            new Borders(this).DrawBorders();
            new ShortcutKeysMenu().Print();
            OpenedMaps.CurrentMap.FullMap = new List<string>();
            OpenedMaps.CurrentView.Print();
            OpenedMaps.CurrentMap.Build(OpenedMaps.CurrentMap.CentralNode);
            OpenedMaps.CurrentMap.CurrentView.Print();
            SetCursorPosition();
        }

        public void Edit(ConsoleKeyInfo currentKey)
        {
            if (currentKey.Modifiers == ConsoleModifiers.Control)
            {
                if (currentKey.Key == ConsoleKey.S)
                {
                    var file = new SaveFile(
                        OpenedMaps.CurrentMap.Title + ".txt",
                        OpenedMaps.CurrentMap.Serialize(),
                        OpenedMaps.CurrentMap.SavedMapFile);
                    OpenedMaps.CurrentMap.SavedMapFile = file.Path;
                }
                else if (currentKey.Key == ConsoleKey.O)
                {
                    _ = new OpenMap(OpenedMaps);
                }
                else if (currentKey.Key == ConsoleKey.E)
                {
                    new Export(OpenedMaps.CurrentMap).ChooseLayout();
                }

                return;
            }

            IControl control = SelectedMenu.Control;
            switch (currentKey.Key)
            {
                case ConsoleKey.Insert:
                    control.Insert();
                    break;
                case ConsoleKey.Enter:
                    SelectedMenu = SelectedMenu is OpenedMaps ? OpenedMaps.CurrentMap : SelectedMenu;
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
                    }
                    else
                    {
                        Console.Clear();
                        Environment.Exit(0);
                    }

                    break;
                default:
                    control.ChangeText(currentKey.KeyChar);
                    break;
            }
        }

        private void SetCursorPosition()
        {
            if (SelectedMenu is OpenedMaps)
            {
                Console.SetCursorPosition(
                    OpenedMaps.CurrentMap.Title.Length + 1 >= HelpMenuWidth
                    ? HelpMenuWidth - 1
                    : OpenedMaps.CurrentMap.Title.Length + 1 - (OpenedMaps.CurrentView.Left - 1),
                    OpenedMaps.Maps.IndexOf(OpenedMaps.CurrentMap) + 1 - OpenedMaps.CurrentView.Top);
            }
            else
            {
                Console.SetCursorPosition(
                    OpenedMaps.CurrentMap.Current.Coordinates.left + OpenedMaps.CurrentMap.Current.Text.Length
                        - OpenedMaps.CurrentMap.CurrentView.Left + HelpMenuWidth + 3,
                    OpenedMaps.CurrentMap.Current.Coordinates.top - OpenedMaps.CurrentMap.CurrentView.Top + 1);
            }
        }
    }
}
