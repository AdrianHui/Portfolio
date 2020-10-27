using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Text : IPattern
    {
        readonly string prefix;
        
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if (prefix == "")
            {
                return new SuccessMatch(text);
            }

            if (!string.IsNullOrEmpty(text) && text.StartsWith(prefix))
            {
                return new SuccessMatch(text.Substring(prefix.Length));
            }

            return new FailedMatch(text);
        }
    }
}
