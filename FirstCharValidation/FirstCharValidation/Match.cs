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
                if (pattern is Character)
                {
                    result = (pattern as Character).CheckCharacter(text);
                }
                else if(pattern is Range)
                {
                    result = (pattern as Range).CheckRange(text);
                }
                else if (pattern is Choice)
                {
                    result = (pattern as Choice).CheckChoice(text);
                }
                else
                {
                    result = (pattern as Sequence).CheckSequence(ref text);
                }

                if (!result)
                {
                    return result;
                }
            }

            return result;
        }

        public bool CheckParams(bool expectedBool, string remainingText)
        {
            return this.Success() == expectedBool && this.RemainingText() == remainingText;
        }
    }
}
