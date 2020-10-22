using Xunit;
namespace StringValidation.Facts
{
    public class OptionalFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnTrueAndNull()
        {
            var optional = new Optional(new Character('a'));
            Assert.True(optional.Match(null).Success()
                    && optional.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputStringIsEmptyStringShouldReturnTrueAndEmptyString()
        {
            var optional = new Optional(new Character('a'));
            Assert.True(optional.Match("").Success()
                    && optional.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputStringContainsPatternCharShouldReturnTrueAndRemainingText()
        {
            var optional = new Optional(new Character('a'));
            Assert.True(optional.Match("aabc").Success()
                    && optional.Match("aabc").RemainingText() == "abc");
        }

        [Fact]
        public void InputStringDoesntContainPatternCharShouldReturnTrueAndInputString()
        {
            var optional = new Optional(new Character('a'));
            Assert.True(optional.Match("bcd").Success()
                    && optional.Match("bcd").RemainingText() == "bcd");
        }

        [Fact]
        public void InputStringContainsCharInPatternRangeShouldReturnTrueAndRemainingText()
        {
            var optional = new Optional(new Range('a', 'f'));
            Assert.True(optional.Match("def").Success()
                    && optional.Match("def").RemainingText() == "ef");
        }

        [Fact]
        public void InputStringDeosntContainCharInPatternRangeShouldReturnTrueAndInputString()
        {
            var optional = new Optional(new Range('a', 'f'));
            Assert.True(optional.Match("ghi").Success()
                    && optional.Match("ghi").RemainingText() == "ghi");
        }
    }
}
