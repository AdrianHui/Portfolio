using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class OneOrMore : IPattern
    {
        IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
