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

        [Fact]
        public void InputStringPartialyMatchesDigitsInPatternRangeShouldReturnTrueAndRemainingText()
        {
            var oneOrMore = new OneOrMore(new Range('0', '9'));
            Assert.True(oneOrMore.Match("123ab").Success());
            Assert.True(oneOrMore.Match("123ab").RemainingText() == "ab");
        }

        [Fact]
        public void InputStringDoesntMatchDigitsInPatternRangeShouldReturnFalseAndInputString()
        {
            var oneOrMore = new OneOrMore(new Range('0', '9'));
            Assert.False(oneOrMore.Match("ab").Success());
            Assert.True(oneOrMore.Match("ab").RemainingText() == "ab");
        }

        [Fact]
        public void InputStringMatchesThePatternShouldReturnTrueAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.True(oneOrMore.Match("aaa").Success());
            Assert.True(oneOrMore.Match("aaa").RemainingText() == "");
        }

        [Fact]
        public void InputStringPartialyMatchesThePatternShouldReturnTrueAndRemainingText()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.True(oneOrMore.Match("aaabcd").Success());
            Assert.True(oneOrMore.Match("aaabcd").RemainingText() == "bcd");
        }

        [Fact]
        public void InputStringDoesntMatchThePatternShouldReturnFalseAndInputString()
        {
            var oneOrMore = new OneOrMore(new Character('a'));
            Assert.False(oneOrMore.Match("bcd").Success());
            Assert.True(oneOrMore.Match("bcd").RemainingText() == "bcd");
        }

        [Fact]
        public void InputStringMatchesOnePatternInChoiceShouldReturnTrueAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Choice(new Character('a'), new Range('0', '9')));
            Assert.True(oneOrMore.Match("aaa").Success());
            Assert.True(oneOrMore.Match("aaa").RemainingText() == "");
        }

        [Fact]
        public void InputStringMatchesBothPatternsInChoiceShouldReturnTrueAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Choice(new Character('a'), new Range('0', '9')));
            Assert.True(oneOrMore.Match("aaa1683").Success());
            Assert.True(oneOrMore.Match("aaa1683").RemainingText() == "");
        }

        [Fact]
        public void InputStringPartialyMatchesPatternsInChoiceShouldReturnTrueAndRemainingText()
        {
            var oneOrMore = new OneOrMore(new Choice(new Character('a'), new Range('0', '9')));
            Assert.True(oneOrMore.Match("aaa1683bc").Success());
            Assert.True(oneOrMore.Match("aaa1683bc").RemainingText() == "bc");
        }

        [Fact]
        public void InputStringDoesntMatchPatternsInChoiceShouldReturnFalseAndInputString()
        {
            var oneOrMore = new OneOrMore(new Choice(new Character('a'), new Range('0', '9')));
            Assert.False(oneOrMore.Match("bc").Success());
            Assert.True(oneOrMore.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void InputStringMatchesOnePatternInSequenceShouldReturnFalseAndInputString()
        {
            var oneOrMore = new OneOrMore(new Sequence(new Character('a'), new Range('0', '9')));
            Assert.False(oneOrMore.Match("aaa").Success());
            Assert.True(oneOrMore.Match("aaa").RemainingText() == "aaa");
        }

        [Fact]
        public void InputStringMatchesBothPatternsInSequenceShouldReturnTrueAndEmptyString()
        {
            var oneOrMore = new OneOrMore(new Sequence(new Character('a'), new Range('0', '9')));
            Assert.True(oneOrMore.Match("a1").Success());
            Assert.True(oneOrMore.Match("a1").RemainingText() == "");
        }

        [Fact]
        public void InputStringDoesntMatchPatternsInSequenceShouldReturnFalseAndInputString()
        {
            var oneOrMore = new OneOrMore(new Sequence(new Character('a'), new Range('0', '9')));
            Assert.False(oneOrMore.Match("bc").Success());
            Assert.True(oneOrMore.Match("bc").RemainingText() == "bc");
        }
    }
}
