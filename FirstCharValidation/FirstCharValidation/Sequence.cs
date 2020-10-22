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
            string newText = text;
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(newText);
                if (!match.Success())
                {
                    return new FailedMatch(text);
                }

                newText = match.RemainingText();
            }

            return new SuccessMatch(newText);
        }
    }
}