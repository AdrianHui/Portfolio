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
            this.pattern = new Many(new Sequence(pattern, separator));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
