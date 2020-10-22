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
            if (match.Success())
            {
                return new SuccessMatch(text.Substring(1));
            }

            return new SuccessMatch(text);
        }
    }
}
