using Xunit;

namespace StringValidation.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match(null, range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringIsEmptyShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideOfRangeShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("dabc", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsUpperCaseShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("Abb", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsSymbolShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("$bb", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsEscapeCharShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("\\ubb", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsDigitShouldReturnFalse()
        {
            var range = new Range('a', 'b');
            Match match = new Match("5bb", range);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsInsideOfRangeShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Match match = new Match("gam", range);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeStartCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Match match = new Match("aaz", range);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToRangeEndCharShouldReturnTrue()
        {
            var range = new Range('a', 'h');
            Match match = new Match("haz", range);
            Assert.True(match.Success());
        }
    }
}
