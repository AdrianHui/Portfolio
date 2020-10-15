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
            IMatch range = new Match(text, new Range(start, end));
            range.Success();
            return range;
        }

        public bool CheckRange(string text)
        {
            return text[0] >= start && text[0] <= end;
        }
    }
}