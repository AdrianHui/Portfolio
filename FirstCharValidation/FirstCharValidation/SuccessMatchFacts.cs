using Xunit;

namespace StringValidation.Facts
{
    public class SuccessMatchFacts
    {
        [Fact]
        public void InputTextIsNullRemainingTextMethodShouldReturnNull()
        {
            IMatch test = new SuccessMatch(null);
            Assert.True(test.RemainingText() == null);
        }

        [Fact]
        public void InputTextIsEmptyStringRemainingTextMethodShouldReturnEmptyString()
        {
            IMatch test = new SuccessMatch("");
            Assert.True(test.RemainingText() == "");
        }

        [Fact]
        public void InputTextIsTextRemainingTextMethodShouldReturnTheText()
        {
            IMatch test = new SuccessMatch("abcd");
            Assert.True(test.RemainingText() == "abcd");
        }

        [Fact]
        public void SuccessMethodShouldReturnTrue()
        {
            IMatch test = new SuccessMatch("abcd");
            Assert.True(test.Success());
        }
    }
}
