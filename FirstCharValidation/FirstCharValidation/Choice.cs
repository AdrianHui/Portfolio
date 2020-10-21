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
            bool result = false;
            foreach (var pattern in patterns)
            {
                if (pattern.Match(text).Success())
                {
                    result = true;
                    break;
                }
            }

            return !string.IsNullOrEmpty(text) && result
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);

        }
    }
}