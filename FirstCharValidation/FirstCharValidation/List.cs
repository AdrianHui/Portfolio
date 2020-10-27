using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class List
    {
        IPattern pattern;

        public List(IPattern pattern, IPattern separator)
        {
            this.pattern = new Many(new Choice(pattern, new Sequence(separator, pattern)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
