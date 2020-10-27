using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Optional : IPattern
    {
        IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = pattern.Match(text);
            return match.Success() ? match : new SuccessMatch(text);
        }
    }
}
