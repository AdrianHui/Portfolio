using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class List : IPattern
    {
        IPattern pattern;

        public List(IPattern pattern, IPattern separator)
        {
            this.pattern = new Optional(new Sequence(pattern, new Many(new Sequence(separator, pattern))));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
