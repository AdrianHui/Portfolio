using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            pattern = new Character('a');
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
