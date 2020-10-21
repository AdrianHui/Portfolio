using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class FailedMatch : IMatch
    {
        string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return false;
        }
    }
}
