using System;
using Xunit;

namespace StringValidation.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void NullInputStringShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(choice.Match(null).Success());
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(choice.Match("").Success());
        }

        [Fact]
        public void InputStringFirstCharIsNotEqualToCharacterAndOutsideOfRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Assert.False(choice.Match("a99").Success());
        }

        [Fact]
        public void InputStringFirstCharIsInRangeShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(choice.Match("1234").Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToCharacterShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Assert.True(choice.Match("01234").Success());
        }

        [Fact]
        public void InputStringFirstCharIsLowercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("a1234").Success());
        }

        [Fact]
        public void InputStringFirstCharIsUppercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.True(hex.Match("B1234").Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideLowercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("h1234").Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideUppercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Assert.False(hex.Match("H1234").Success());
        }
    }
}
