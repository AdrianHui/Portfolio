using Xunit;

namespace StringValidation.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match(null).Success());
        }

        [Fact]
        public void InputStringIsEmptyShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("").Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideOfRangeShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("dabc").Success());
        }

        [Fact]
        public void InputStringFirstCharIsUpperCaseShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("Abb").Success());
        }

        [Fact]
        public void InputStringFirstCharIsSymbolShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("$bb").Success());
        }

        [Fact]
        public void InputStringFirstCharIsEscapeCharShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("\\bb").Success());
        }

        [Fact]
        public void InputStringFirstCharIsDigitShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Assert.False(range.Match("5bb").Success());
        }

        [Fact]
        public void InputStringFirstCharIsInsideOfRangeShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Assert.True(range.Match("gam").Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeStartCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Assert.True(range.Match("aaz").Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeEndCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Assert.True(range.Match("haz").Success());
        }
    }
}
