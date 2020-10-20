using Xunit;

namespace StringValidation.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = null;
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringIsEmptyShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideOfRangeShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "dabc";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsUpperCaseShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "Abb";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsSymbolShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "$bb";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsEscapeCharShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "\\bb";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsDigitShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            string stringToCheck = "5bb";
            Assert.False(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsInsideOfRangeShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            string stringToCheck = "gam";
            Assert.True(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeStartCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            string stringToCheck = "aaz";
            Assert.True(range.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeEndCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            string stringToCheck = "haz";
            Assert.True(range.Match(stringToCheck).Success());
        }
    }
}
