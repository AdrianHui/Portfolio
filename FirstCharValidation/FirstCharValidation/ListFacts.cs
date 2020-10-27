using Xunit;

namespace StringValidation.Facts
{
    public class ListFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnTrueAndNull()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match(null).Success());
            Assert.True(list.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputStringIsEmptyStringShouldReturnTrueAndEmptyString()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("").Success());
            Assert.True(list.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputStringMatchesPatternsInListShouldReturnTrueAndEmptyString()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1,2,3").Success());
            Assert.True(list.Match("1,2,3").RemainingText() == "");
        }

        [Fact]
        public void InputStringPartialyMatchesPatternsInListShouldReturnTrueAndEmptyString()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1,2,3,").Success());
            Assert.True(list.Match("1,2,3,").RemainingText() == ",");
        }
    }
}
