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
            Assert.False(pattern.Match("").Success());
        }

        [Fact]
        public void InputStringNotStartingWithPatternShouldReturnFalse()
        {
            Character pattern = new Character('x');
            Assert.False(pattern.Match("abcd").Success());
        }

        [Fact]
        public void InputStringStartingWithPatternShouldReturnTrue()
        {
            Character pattern = new Character('x');
            Assert.True(pattern.Match("xunit").Success());
        }

        [Fact]
        public void InputStringStartingWithUppercasePatternShouldReturnFalse()
        {
            Character pattern = new Character('x');
            Assert.False(pattern.Match("Xunit").Success());
        }
    }
}
