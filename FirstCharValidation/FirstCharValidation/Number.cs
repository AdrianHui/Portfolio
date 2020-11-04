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
            var digit = new Choice(new Range('0', '9'));
            var digits = new OneOrMore(digit);
            var sign = new Any("+-");
            var exponent = new Any("eE");
            var fraction = new Sequence(new Character('.'), new Optional(exponent), digits);
            var startsWithZero = new Choice(new Character('0'), digits);
            var decimalPart = new Sequence(exponent, new Optional(sign), digits);
            pattern = new Sequence(new Optional(sign), startsWithZero,
                                    new Optional(fraction), new Optional(decimalPart));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
