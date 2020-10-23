using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Many : IPattern
    {
        IPattern pattern;

        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccessMatch(text);
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }

            return match.Success() ? new SuccessMatch(text) : new SuccessMatch(match.RemainingText());
        }
    }
}
