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

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach(var pattern in patterns)
            {
                if (pattern.Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
