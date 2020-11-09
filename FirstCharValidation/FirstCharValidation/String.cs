using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var hex = new Choice(new Range('0', '9'), new Range('A', 'F'), new Range('a', 'f'));
            var escape = new Choice(new Sequence(new Character('u'), hex, hex, hex, hex),
                                    new Any("bfnrt/\"\\"));
            var character = new Choice(new Range(' ', char.MaxValue, "\"\\"),
                                       new Sequence(new Character('\\'), escape));
            var characters = new Many(character);
            pattern = new Sequence(new Character('"'), characters, new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
