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
            Match match = new Match(null, choice);
            Assert.False(match.Success());
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Match match = new Match("", choice);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsNotEqualToCharacterAndOutsideOfRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Match match = new Match("a99", choice);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsInRangeShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Match match = new Match("1234", choice);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsEqualToCharacterShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            Match match = new Match("01234", choice);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsLowercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Match match = new Match("a1234", hex);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsUppercaseHexCharShouldReturnTrue()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Match match = new Match("B1234", hex);
            Assert.True(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideLowercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Match match = new Match("h1234", hex);
            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringFirstCharIsOutsideUppercaseHexCharRangeShouldReturnFalse()
        {
            Choice choice = new Choice(new Character('0'), new Range('1', '9'));
            var hex = new Choice(choice, new Choice(new Range('a', 'f'), new Range('A', 'F')));
            Match match = new Match("H1234", hex);
            Assert.False(match.Success());
        }
    }
}
