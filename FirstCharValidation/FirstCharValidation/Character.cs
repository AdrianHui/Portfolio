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

        public IMatch Match(string text)
        {
            IMatch character = new Match(text, new Character(pattern));
            character.Success();
            return character;
        }

        public bool CheckCharacter(string text)
        {
            return text[0] == pattern;
        }
    }
}