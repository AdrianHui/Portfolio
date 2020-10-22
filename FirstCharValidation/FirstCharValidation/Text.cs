using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Text
    {
        string prefix;
        
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

            foreach (var character in text)
            {
                if (character != prefix[0])
                {
                    return new FailedMatch(text);
                }

                prefix = prefix.Substring(1);
            }

            return new SuccessMatch(prefix);
        }
    }
}
