using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class SuccessMatch : IMatch
    {
        string text;

        public SuccessMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return true;
        }
    }
}