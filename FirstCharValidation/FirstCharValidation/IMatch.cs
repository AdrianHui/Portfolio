using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
