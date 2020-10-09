using Xunit;

namespace StringValidation.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void NullInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');

            Assert.False(pattern.Match(null));
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');

            Assert.False(pattern.Match(""));
        }

        [Fact]
        public void InputStringNotStartingWithPatternShouldReturnFalse()
        {
            Character pattern = new Character('x');

            Assert.False(pattern.Match("abcd"));
        }

        [Fact]
        public void InputStringStartingWithPatternShouldReturnTrue()
        {
            Character pattern = new Character('x');

            Assert.True(pattern.Match("xunit"));
        }
    }
}
