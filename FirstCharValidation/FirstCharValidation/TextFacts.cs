using Xunit;

namespace StringValidation.Facts
{
    public class TextFacts
    {
        [Fact]
        public void InputStringIsNullAndPrefixContainsTextShouldReturnFalseAndRemainingTextShouldReturnNull()
        {
            Text text = new Text("abc");
            IMatch match = text.Match(null);
            Assert.False(match.Success());
            Assert.True(match.RemainingText() == null);
        }

        [Fact]
        public void InputStringIsEmptyStringShouldReturnFalseAndRemainingTextShouldReturnEmptyString()
        {
            Text text = new Text("abc");
            IMatch match = text.Match("");
            Assert.False(match.Success());
            Assert.True(match.RemainingText() == "");
        }

        [Fact]
        public void InputStringIsNullAndPrefixDoesntContainsTextShouldReturnTrueAndRemainingTextShouldReturnTheText()
        {
            Text text = new Text("");
            IMatch match = text.Match("abc");
            Assert.True(match.Success() && match.RemainingText() == "abc");
        }
        
        [Fact]
        public void InputStringFullyMatchesPrefixShouldRetrunTrueAndRemainingTextShouldReturnEmptyString()
        {
            Text text = new Text("abCd");
            IMatch match = text.Match("abCd");
            Assert.True(match.Success() && match.RemainingText() == "");
        }

        [Fact]
        public void InputStringPartialyMatchesPrefixShouldRetrunTrueAndRemainingTextShouldReturnRemainingPrefix()
        {
            Text text = new Text("abCdEf");
            IMatch match = text.Match("abCd");
            Assert.True(match.Success() && match.RemainingText() == "Ef");
        }

        [Fact]
        public void InputStringDoesntMatchPrefixShouldRetrunFalseAndRemainingTextShouldReturnRemainingTheText()
        {
            Text text = new Text("abCdEf");
            IMatch match = text.Match("ghi");
            Assert.False(match.Success());
            Assert.True(match.RemainingText() == "ghi");
        }
    }
}
