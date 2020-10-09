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

        [Fact]
        public void InputStringFirstCharIsOutsideOfRangeShouldReturnFalse()
        {
            var digit = new Range('a', 'c');
            string stringToCheck = "dabc";
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsUpperCaseShouldReturnFalse()
        {
            var digit = new Range('a', 'c');
            string stringToCheck = "Abb";
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsSymbolShouldReturnFalse()
        {
            var digit = new Range('a', 'c');
            string stringToCheck = "$bb";
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsEscapeCharShouldReturnFalse()
        {
            var digit = new Range('a', 'z');
            string stringToCheck = "\\ubb";
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsDigitShouldReturnFalse()
        {
            var digit = new Range('a', 'c');
            string stringToCheck = "5bb";
            Assert.False(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsInsideOfRangeShouldReturnTrue()
        {
            var digit = new Range('a', 'h');
            string stringToCheck = "gam";
            Assert.True(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeStartCharShouldReturnTrue()
        {
            var digit = new Range('a', 'h');
            string stringToCheck = "aaz";
            Assert.True(digit.Match(stringToCheck));
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeEndCharShouldReturnTrue()
        {
            var digit = new Range('a', 'h');
            string stringToCheck = "haz";
            Assert.True(digit.Match(stringToCheck));
        }
    }
}
