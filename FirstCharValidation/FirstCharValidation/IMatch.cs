using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
