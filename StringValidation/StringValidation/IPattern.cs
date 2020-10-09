using System;
using System.Collections.Generic;
using System.Text;

namespace StringValidation
{
    interface IPattern
    {
        bool Match(string text);
    }
}
