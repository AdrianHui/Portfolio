using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class Node
    {
        public Node()
        {
        }

        public string Text { get; private set; } = "new node";

        public void DisplayNode()
        {
            Console.WriteLine(WrapText(Text));
        }

        public void ChangeNodeText()
        {
            const int low = 31;
            const int high = 127;
            var key = Console.ReadKey();
            Text = key.KeyChar switch
            {
                '\b' => Text.Substring(0, Text.Length - 1),
                var x when x > low && x < high => Text + x,
                _ => throw new NotImplementedException()
            };
        }

        private string WrapText(string text)
        {
            return new string('-', text.Length + 2)
                   + "\n|" + text + "|\n"
                   + new string('-', text.Length + 2);
        }
    }
}
