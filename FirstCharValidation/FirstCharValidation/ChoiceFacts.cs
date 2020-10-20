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
            string stringToCheck = null;
            Assert.False(choice.Match(stringToCheck).Success());
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            string stringToCheck = "";
            Assert.False(choice.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsNotEqualToCharacterAndOutsideOfRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            string stringToCheck = "a99";
            Assert.False(choice.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsInRangeShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            string stringToCheck = "1234";
            Assert.True(choice.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToCharacterShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            string stringToCheck = "01234";
            Assert.True(choice.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsLowercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            string stringToCheck = "a1234";
            Assert.True(hex.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsUppercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            string stringToCheck = "B1234";
            Assert.True(hex.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideLowercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            string stringToCheck = "h1234";
            Assert.False(hex.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideUppercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            string stringToCheck = "H1234";
            Assert.False(hex.Match(stringToCheck).Success());
        }
    }
}
