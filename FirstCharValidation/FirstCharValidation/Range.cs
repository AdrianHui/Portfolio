using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Range : IPattern
    {
        char start;
        char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}