using System;
using System.Collections.Generic;
using System.Text;

namespace FirstCharValidation
{
    class Range
    {
        char start;
        char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
            return !string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end;
        }
    }
}