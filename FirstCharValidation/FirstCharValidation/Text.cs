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
            if (string.IsNullOrEmpty(text))
            {
                return new FailedMatch(text);
            }

            if (prefix == "")
            {
                return new SuccessMatch(text);
            }

            int i;
            for (i = 0; i < text.Length; i++)
            {
                if (text[i] != prefix[i])
                {
                    return new FailedMatch(text);
                }
            }

            return new SuccessMatch(prefix.Substring(i));
        }
    }
}
