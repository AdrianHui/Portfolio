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
            if (string.IsNullOrEmpty(text))
            {
                return new SuccessMatch(text);
            }

            IMatch match = new SuccessMatch(text);
            foreach (var charactrer in text)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new SuccessMatch(match.RemainingText());
                }
            }

            return new SuccessMatch(text);
        }
    }
}
