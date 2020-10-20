using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Match : IMatch
    {
        string text;
        IPattern[] patterns;

        public Match(string text, params IPattern[] patterns)
        {
            this.text = text;
            this.patterns = patterns;
        }

        public string RemainingText()
        {
            this.text = text.Substring(1);
            return this.text;
        }

        public bool Success()
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            bool result = false;
            foreach (var pattern in patterns)
            {
                if (pattern is Character && (pattern as Character).CheckCharacter(text))
                {
                    result = true;
                }
                else if(pattern is Range && (pattern as Range).CheckRange(text))
                {
                    result = true;
                }
                else if (pattern is Choice && (pattern as Choice).CheckChoice(text))
                {
                    result = true;
                }
                else if (pattern is Sequence && !(pattern as Sequence).CheckSequence(ref text))
                {
                    return false;
                }
            }

            return result;
        }
    }
}
