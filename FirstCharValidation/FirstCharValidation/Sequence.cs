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
            IMatch sequence = new Match(text, patterns);
            sequence.Success();
            sequence.RemainingText();
            return sequence;
        }

        public bool CheckSequence(ref string text)
        {
            foreach (var pattern in patterns)
            {
                Match match = new Match(text, pattern);
                if (!match.Success())
                {
                    return false;
                }

                text = match.RemainingText();
            }

            return true;
        }
    }
}
