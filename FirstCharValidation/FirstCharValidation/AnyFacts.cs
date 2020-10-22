using Xunit;

namespace StringValidation.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void InputStringNullShouldReturnFalseAndRemainingTextNull()
        {
            Any any = new Any("eE");
            Assert.False(any.Match(null).Success());
            Assert.True(any.Match(null).RemainingText() == null);
        }

        [Fact]
        public void InputStringEmptyStringShouldReturnFalseAndRemainingTextEmptyString()
        {
            Any any = new Any("eE");
            Assert.False(any.Match("").Success());
            Assert.True(any.Match("").RemainingText() == "");
        }

        [Fact]
        public void InputStringFirstCharIsNotInAnyAcceptedShouldReturnFalseAndRemainingTextInputString()
        {
            Any any = new Any("eE");
            Assert.False(any.Match("abc").Success());
            Assert.True(any.Match("abc").RemainingText() == "abc");
        }

        [Fact]
        public void AnyAcceptedStringContainsInoutStringFirstCharShouldReturnTrueAndRemainingTextShouldReturnRemainingString()
        {
            Any any = new Any("eE");
            Assert.True(any.Match("Efg").Success());
            Assert.True(any.Match("Efg").RemainingText() == "fg");
        }
    }
}
