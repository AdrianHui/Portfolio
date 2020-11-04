using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var oneNine = new Range('1', '9');
            var digit = new Choice(new Character('0'), oneNine);
            var sign = new Any("+-");
            var exponent = new Any("eE");
            var fraction = new Sequence(new Character('.'), new Optional(exponent), new OneOrMore(digit));
            pattern = new Sequence(new Optional(sign),
                                    new Choice(new Character('0'), new OneOrMore(digit)),
                                    new Optional(fraction),
                                    new Optional(new Sequence(exponent, new Optional(sign),
                                                new OneOrMore(digit))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
