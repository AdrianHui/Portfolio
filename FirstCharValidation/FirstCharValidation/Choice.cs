using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Choice : IPattern
    {
        IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccessMatch(text);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (match.Success())
                {
                    return match;
                }
            }

            return new FailedMatch(text);

        }
    }
}