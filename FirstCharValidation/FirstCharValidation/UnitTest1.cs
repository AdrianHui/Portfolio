using System;
using System.Text.RegularExpressions;
using Xunit;

namespace FirstCharValidation.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnFalse()
        {
            var digit = new Range('a', 'b');
            string stringToCheck = null;
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringIsEmptyShouldReturnFalse()
        {
            var digit = new Range('a', 'b');
            string stringToCheck = "";
            Assert.False(digit.Match(stringToCheck));
        }
    }
}
