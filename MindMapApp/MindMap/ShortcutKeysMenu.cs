using System;

namespace MindMap
{
    class ShortcutKeysMenu
    {
        public ShortcutKeysMenu()
        {
        }

        public void Print()
        {
            string[] elements =
            {
                "\u001b[33mInsert\u001b[0m - add new map",
                "       - add new child node",
                "\u001b[33mEnter\u001b[0m - open map",
                "      - add new sibling node",
                "\u001b[33mEsc\u001b[0m - exit map / exit app",
                "\u001b[33mDelete\u001b[0m - delete current node",
                "\u001b[33mBackspace\u001b[0m - erase character",
                "\u001b[33mArrows\u001b[0m - navigation",
                "\u001b[33mCTRL + S\u001b[0m - save map",
                "\u001b[33mCTRL + O\u001b[0m - open map",
                "\u001b[33mCTRL + E\u001b[0m - export map"
            };
            var helpMentuTop = Console.WindowHeight - 13;
            for (int i = 0; i < elements.Length; i++)
            {
                Console.SetCursorPosition(1, helpMentuTop++);
                Console.WriteLine(elements[i]);
            }
        }
    }
}
