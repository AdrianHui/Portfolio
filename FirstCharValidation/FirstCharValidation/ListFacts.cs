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
        public void InputStringPartialyMatchesPatternsInListShouldReturnTrueAndRemainingText()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1,2,3,").Success());
            Assert.True(list.Match("1,2,3,").RemainingText() == ",");
        }

        [Fact]
        public void InputStringNotHavingSeparatorShouldReturnTrueAndRemainingText()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("123").Success());
            Assert.True(list.Match("123").RemainingText() == "23");
        }

        [Fact]
        public void InputStringWithoutSeparatorPartialyMatchesPatternsInListShouldReturnTrueAndRemainingText()
        {
            var list = new List(new Range('0', '9'), new Character(','));
            Assert.True(list.Match("1a").Success());
            Assert.True(list.Match("1a").RemainingText() == "a");
        }

        [Fact]
        public void InputStringWithDiferentSeparatorPatternsMatchesThePatternsShouldReturnTrueAndEmptyString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").Success());
            Assert.True(list.Match("1; 22  ;\n 333 \t; 22").RemainingText() == "");
        }

        [Fact]
        public void InputStringWithDiferentSeparatorPatternsPartialyMatchesThePatternsShouldReturnTrueAndRemainingText()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("1 \n").Success());
            Assert.True(list.Match("1 \n").RemainingText() == " \n");
        }

        [Fact]
        public void InputStringWithDiferentSeparatorPatternsNotMatchingThePatternsShouldReturnTrueAndInputString()
        {
            var digits = new OneOrMore(new Range('0', '9'));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            Assert.True(list.Match("abc").Success());
            Assert.True(list.Match("abc").RemainingText() == "abc");
        }
    }
}
