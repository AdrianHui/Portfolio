using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Character : IPattern
    {
        char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] == pattern
                    ? new SuccessMatch(text.Substring(1))
                    : (IMatch) new FailedMatch(text);
        }
    }
}