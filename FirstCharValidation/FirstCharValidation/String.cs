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
            var digit = new Range('0', '9');
            var hex = new Choice(digit, new Range('A', 'F'), new Range('a', 'f'));
            var unicode = new Sequence(new Character('\\'), new Character('u'), hex, hex, hex, hex);
            var escape = new Choice(unicode, new Sequence(new Character('\\'), new Any("bfnrt/\"\\")));
            var character = new Range(' ', char.MaxValue, "\"\\");
            var characters = new OneOrMore(new Sequence(new Optional(escape), character));
            var jsonString = new Sequence(new Character('"'), characters, new Character('"'));
            pattern = jsonString;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
