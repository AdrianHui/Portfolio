using Xunit;

namespace StringValidation.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void NullInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');
            string stringToCheck = null;
            Assert.False(pattern.Match(stringToCheck).Success());
        }

        [Fact]
        public void EmptyInputStringShouldReturnFalse()
        {
            Character pattern = new Character('x');
            string stringToCheck = "";
            Assert.False(pattern.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringNotStartingWithPatternShouldReturnFalse()
        {
            Character pattern = new Character('x');
            string stringToCheck = "abcd";
            Assert.False(pattern.Match(stringToCheck).Success());
        }

        [Fact]
        public void InputStringStartingWithPatternShouldReturnTrue()
        {
            Character pattern = new Character('x');
            string stringToCheck = "xunit";
            Assert.True(pattern.Match(stringToCheck).Success());
        }
    }
}
