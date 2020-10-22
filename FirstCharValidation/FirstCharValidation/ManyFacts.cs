using Xunit;

namespace StringValidation.Facts
{
    public class ManyFacts
    {
        [Fact]
        public void InputStringIsNullShouldReturnTrueAndNull()
        {
            var pattern = new Many(new Character('a'));
            Assert.True(pattern.Match(null).Success()
                    && pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputStringIsEmptyStringShouldReturnTrueAndEmptyString()
        {
            var pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("").Success()
                    && pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputStringContainsPatternMultipleTimesShouldReturnTrueAndRemainingText()
        {
            var pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("aaaabc").Success()
                    && pattern.Match("aaaabc").RemainingText() == "bc");
        }

        [Fact]
        public void InputStringDoesntContainPatternShouldReturnTrueAndInputString()
        {
            var pattern = new Many(new Character('a'));
            Assert.True(pattern.Match("bc").Success()
                    && pattern.Match("bc").RemainingText() == "bc");
        }

        [Fact]
        public void InputStringContainsCharsInPatternRangeShouldReturnTrueAndRemainingText()
        {
            var pattern = new Many(new Range('0', '9'));
            Assert.True(pattern.Match("123ab1234").Success()
                    && pattern.Match("123ab1234").RemainingText() == "ab1234");
        }

        [Fact]
        public void InputStringDoesntContainCharsInPatternRangeShouldReturnTrueAndInputString()
        {
            var pattern = new Many(new Range('0', '9'));
            Assert.True(pattern.Match("abc").Success()
                    && pattern.Match("abc").RemainingText() == "abc");
        }
    }
}
