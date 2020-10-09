using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Character : IPattern
    {
        char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public bool Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == pattern;
        }
    }
}
