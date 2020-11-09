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
            var character = new Range(' ', char.MaxValue, "\"\\");
            var characters = new OneOrMore(new Choice(character,
                                                      new Sequence(new Character('\\'), escape)));
            pattern = new Sequence(new Character('"'), new Optional(characters), new Character('"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
