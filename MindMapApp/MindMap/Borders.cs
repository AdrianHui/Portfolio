using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class Borders : ApplicationViewCoordinates
    {
        private readonly MindMaps appView;

        public Borders(MindMaps appView)
        {
            this.appView = appView;
        }

        public void DrawBorders()
        {
            OpenedMapsBorders();
            HelpMenuBorders();
            MapBorders();
        }

        private void OpenedMapsBorders()
        {
            Console.WriteLine(appView.SelectedMenu is OpenedMaps
                ? "\u001b[32m┌─ Opened Maps ".PadRight(OpenedMapsMenuWidth + 5, '─') + "┐ "
                : "┌─ Opened Maps ".PadRight(OpenedMapsMenuWidth, '─') + "┐ ");
            while (Console.CursorTop != WindowHeight - 12)
            {
                Console.WriteLine("│" + "".PadRight(OpenedMapsMenuWidth - 1, ' ') + "│ ");
            }

            Console.WriteLine("└" + "".PadRight(OpenedMapsMenuWidth - 1, '─') + "┘ \u001b[0m");
        }

        private void HelpMenuBorders()
        {
            Console.WriteLine("┌─ Shortcut Keys ".PadRight(OpenedMapsMenuWidth, '─') + "┐ ");
            while (Console.CursorTop != WindowHeight - 2)
            {
                Console.WriteLine("│" + "".PadRight(OpenedMapsMenuWidth - 1, ' ') + "│ ");
            }

            Console.WriteLine("└" + "".PadRight(OpenedMapsMenuWidth - 1, '─') + "┘ ");
        }

        private void MapBorders()
        {
            int top = 0;
            Console.SetCursorPosition(OpenedMapsMenuWidth + 2, top++);
            Console.WriteLine(appView.SelectedMenu is Map
                ? "\u001b[32m┌" + "".PadRight(WindowWidth - 2 - OpenedMapsMenuWidth - 2, '─') + "┐"
                : "┌" + "".PadRight(WindowWidth - 2 - OpenedMapsMenuWidth - 2, '─') + "┐");
            while (Console.CursorTop != WindowHeight - 2)
            {
                Console.SetCursorPosition(OpenedMapsMenuWidth + 2, top++);
                Console.WriteLine("│" + "".PadRight(WindowWidth - 2 - OpenedMapsMenuWidth - 2, ' ') + "│");
            }

            Console.SetCursorPosition(OpenedMapsMenuWidth + 2, top);
            Console.WriteLine("└" + "".PadRight(WindowWidth - 2 - OpenedMapsMenuWidth - 2, '─') + "┘\u001b[0m");
        }
    }
}
