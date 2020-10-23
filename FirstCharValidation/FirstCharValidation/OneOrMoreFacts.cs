using Xunit;

namespace StringValidation.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnFalseAndNull()
        {
            var oneOrMore = new OneOrMore(new Range('0', '9'));
            Assert.False(oneOrMore.Match(null).Success());
            Assert.True(oneOrMore.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputStringIsEmptyStringShouldReturnFalseAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Range('0', '9'));
            Assert.False(oneOrMore.Match("").Success());
            Assert.True(oneOrMore.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputStringContainsOnlyDigitsInPatternRangeShouldReturnTrueAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Range('0', '9'));
            Assert.True(oneOrMore.Match("123").Success());
            Assert.True(oneOrMore.Match("123").RemainingText() == "");
        }
    }
}
