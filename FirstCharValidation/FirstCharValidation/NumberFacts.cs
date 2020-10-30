using Xunit;

namespace StringValidation.Facts
{
    public class NumberFacts
    {
        [Fact]
        public void CanBeZero()
        {
            var pattern = new Choice(new OneOrMore(new Range('1', '9')));
            Assert.True(pattern.Match("0").Success());
            Assert.True(pattern.Match("0").RemainingText() == "");
        }

        [Fact]
        public void DoesntContainsLetters()
        {
            var pattern = new OneOrMore(new Range('0', '9'));
            Assert.False(pattern.Match("b").Success());
            Assert.True(pattern.Match("b").RemainingText() == "b");
        }

        [Fact]
        public void CanBeSingleDigit()
        {
            var pattern = new OneOrMore(new Range('0', '9'));
            Assert.True(pattern.Match("2").Success());
            Assert.True(pattern.Match("2").RemainingText() == "");
        }

        [Fact]
        public void CanHaveMultipleDigits()
        {
            var pattern = new OneOrMore(new Range('0', '9'));
            Assert.True(pattern.Match("21").Success());
            Assert.True(pattern.Match("21").RemainingText() == "");
        }

        [Fact]
        public void CantBeNull()
        {
            var pattern = new OneOrMore(new Range('0', '9'));
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void CantBeEmpty()
        {
            var pattern = new OneOrMore(new Range('0', '9'));
            Assert.False(pattern.Match("").Success());
            Assert.True(pattern.Match("").RemainingText() == "");
        }

        [Fact]
        public void CantStartWithZero()
        {
            var pattern = new Choice(new Sequence(new Character('0'), new Text(string.Empty)), new OneOrMore(new Range('1', '9')));
            Assert.False(pattern.Match("01").Success());
        }
    }
}
