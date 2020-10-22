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

            bool result = true;
            foreach (var character in text)
            {
                IMatch match = new Character(character).Match(prefix);
                if (!match.Success())
                {
                    result = false;
                    break;
                }

                prefix = prefix.Substring(1);
            }

            return result ? new SuccessMatch(prefix) : (IMatch) new FailedMatch(text);
        }
    }
}
