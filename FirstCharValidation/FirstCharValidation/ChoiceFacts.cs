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

        [Fact]
        public void InputStringFirstCharIsInSequenceShouldReturnTrueAndRemainingText()
        {
            var choice = new Choice(new Sequence(new Character('a'), new Range('1', '3')));
            Assert.True(choice.Match("a321bcd").Success());
            Assert.True(choice.Match("a321bcd").RemainingText() == "21bcd");
        }

        [Fact]
        public void InputStringFirstCharIsNotInSequenceShouldReturnFalseAndInputString()
        {
            var choice = new Choice(new Sequence(new Character('a'), new Range('1', '3')));
            Assert.False(choice.Match("bcd").Success());
            Assert.True(choice.Match("bcd").RemainingText() == "bcd");
        }

        [Fact]
        public void InputStringPartialyMatchesPrefixShouldReturnTrueAndRemainingText()
        {
            var choice = new Choice(new Text("bcd"));
            Assert.True(choice.Match("bcdef").Success());
            Assert.True(choice.Match("bcdef").RemainingText() == "ef");
        }

        [Fact]
        public void InputStringDoesntMatchPrefixShouldReturnFalseAndInputString()
        {
            var choice = new Choice(new Text("abc"));
            Assert.False(choice.Match("def").Success());
            Assert.True(choice.Match("def").RemainingText() == "def");
        }

        [Fact]
        public void InputStringMatchesTheSequenceShouldReturnTrueAndRemainingText()
        {
            var choice = new Choice(new Text("abc"),
                new Sequence(new Character('d'), new Range('e', 'h')));
            Assert.True(choice.Match("def").Success());
            Assert.True(choice.Match("def").RemainingText() == "f");
        }

        [Fact]
        public void ShouldAddPatternToExistingChoice()
        {
            var choice = new Choice(new Range('0', '9'), new Range('A', 'F'));
            choice.Add(new Range('a', 'f'));
            Assert.True(choice.Match("ab").Success());
            Assert.True(choice.Match("ab").RemainingText() == "b");
        }

        [Fact]
        public void ShouldAddSequenceOfPatternsToExistingChoice()
        {
            var choice = new Choice(new Range('0', '9'), new Range('A', 'F'));
            choice.Add(new Sequence(new Range('a', 'f'), new Range('a', 'f')));
            Assert.True(choice.Match("ab").Success());
            Assert.True(choice.Match("ab").RemainingText() == "");
        }
    }
}
