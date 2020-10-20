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
            IMatch choice = new Match(text, patterns);
            return choice;
            
        }

        public bool CheckChoice(string text)
        {
            foreach (var pattern in patterns)
            {
                Match match = new Match(text, pattern);
                if (match.Success())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
