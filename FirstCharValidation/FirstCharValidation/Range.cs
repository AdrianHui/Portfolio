using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Range : IPattern
    {
        char start;
        char end;
        string excludedChars;
        public Range(char start, char end, string excludedChars = "")
        {
            this.start = start;
            this.end = end;
            this.excludedChars = excludedChars;
        }

        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && !excludedChars.Contains(text[0])
                && text[0] >= start && text[0] <= end
                ? new SuccessMatch(text.Substring(1))
                : (IMatch)new FailedMatch(text);
        }
    }
}