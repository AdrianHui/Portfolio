using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        IMatch sequence;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            this.sequence = new Match(text, patterns);
            return sequence;
        }

        public bool CheckSequence(ref string text)
        {
            foreach (var pattern in patterns)
            {
                this.sequence = new Match(text, pattern);
                if (!sequence.Success())
                {
                    return false;
                }

                text = sequence.RemainingText();
            }

            return true;
        }
    }
}
