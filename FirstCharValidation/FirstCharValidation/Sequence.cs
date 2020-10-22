using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccessMatch(text);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new FailedMatch(text);
                }
            }

            return match;
        }
    }
}