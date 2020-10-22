using Xunit;

namespace StringValidation.Facts
{
    public class FailedMatchFacts
    {
        [Fact]
        public void InputTextIsNullRemainingTextMethodShouldReturnNull()
        {
            IMatch test = new FailedMatch(null);
            Assert.True(test.RemainingText() == null);
        }

        [Fact]
        public void InputTextIsEmptyStringRemainingTextMethodShouldReturnEmptyString()
        {
            IMatch test = new FailedMatch("");
            Assert.True(test.RemainingText() == "");
        }

        [Fact]
        public void InputTextIsTextRemainingTextMethodShouldReturnTheText()
        {
            IMatch test = new FailedMatch("abcd");
            Assert.True(test.RemainingText() == "abcd");
        }

        [Fact]
        public void SuccessMethodShouldReturnFalse()
        {
            IMatch test = new FailedMatch("abcd");
            Assert.False(test.Success());
        }
    }
}
