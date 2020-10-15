using Xunit;

namespace StringValidation.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void NullInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');

            Assert.False(pattern.Match(null).Success());
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');
            Match match = new Match("", pattern);

            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringNotStartingWithPatternShouldReturnFalse()
        {
            Character pattern = new Character('x');
            Match match = new Match("abcd", pattern);

            Assert.False(match.Success());
        }

        [Fact]
        public void InputStringStartingWithPatternShouldReturnTrue()
        {
            Character pattern = new Character('x');
            Match match = new Match("xunit", pattern);

            Assert.True(match.Success());
        }
    }
}
