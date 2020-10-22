﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    class Sequence : IPattern
    {
        IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            bool result = true;
            string newText = text;
            foreach (var pattern in patterns)
            {
                IMatch match = pattern.Match(newText);
                if (!match.Success())
                {
                    result = false;
                    break;
                }

                newText = match.RemainingText();
            }

            return !string.IsNullOrEmpty(text) && result
                ? new SuccessMatch(newText)
                : (IMatch)new FailedMatch(text);
        }
    }
}