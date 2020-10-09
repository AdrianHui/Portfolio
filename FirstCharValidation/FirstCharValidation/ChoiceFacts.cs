using System;
using Xunit;

namespace StringValidation.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void NullInputStringShouldReturnFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.False(digit.Match(null));
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.False(digit.Match(""));
        }

        [Fact]
        public void InputStringFirstCharIsNotEqualToCharacterAndOutsideOfRangeShouldReturnFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.False(digit.Match("a99"));
        }

        [Fact]
        public void InputStringFirstCharIsInRangeShouldReturnTrue()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.True(digit.Match("1234"));
        }

        [Fact]
        public void InputStringFirstCharIsEqualToCharacterShouldReturnTrue()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));

            Assert.True(digit.Match("01234"));
        }

        [Fact]
        public void InputStringFirstCharIsLowercaseHexCharShouldReturnTrue()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            Assert.True(hex.Match("a1234"));
        }

        [Fact]
        public void InputStringFirstCharIsUppercaseHexCharShouldReturnTrue()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            Assert.True(hex.Match("B1234"));
        }

        [Fact]
        public void InputStringFirstCharIsOutsideLowercaseHexCharRangeShouldReturnFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            Assert.False(hex.Match("h1234"));
        }

        [Fact]
        public void InputStringFirstCharIsOutsideUppercaseHexCharRangeShouldReturnFalse()
        {
            Choice digit = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(digit, new Choice(new Range('a', 'f'), new Range('A', 'F')));

            Assert.False(hex.Match("H1234"));
        }
    }
}
