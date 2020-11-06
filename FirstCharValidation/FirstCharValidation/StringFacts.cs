using Xunit;

namespace StringValidation.Facts
{
    public class StringFacts
    {
        [Fact]
        public void MustBeWrappedInDoubleQuotes()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted("abc")).Success());
            Assert.True(pattern.Match(Quoted("abc")).RemainingText() == "");
        }

        [Fact]
        public void AlwaysStartsWithQuotes()
        {
            var pattern = new String();
            Assert.False(pattern.Match("abc\"").Success());
            Assert.True(pattern.Match("abc\"").RemainingText() == "abc\"");
        }

        [Fact]
        public void AlwaysEndsWithQuotes()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"abc").Success());
            Assert.True(pattern.Match("\"abc").RemainingText() == "\"abc");
        }

        [Fact]
        public void IsNotNull()
        {
            var pattern = new String();
            Assert.False(pattern.Match(null).Success());
            Assert.True(pattern.Match(null).RemainingText() == null);
        }

        [Fact]
        public void IsNotEmpty()
        {
            var pattern = new String();
            Assert.False(pattern.Match(string.Empty).Success());
            Assert.True(pattern.Match(string.Empty).RemainingText() == string.Empty);
        }

        [Fact]
        public void IsNotQuotedEmptyString()
        {
            var pattern = new String();
            Assert.False(pattern.Match(Quoted("")).Success());
            Assert.True(pattern.Match(Quoted("")).RemainingText() == "\"\"");
        }

        [Fact]
        public void HasStartAndEndQuotes()
        {
            var pattern = new String();
            Assert.False(pattern.Match("\"").Success());
            Assert.True(pattern.Match("\"").RemainingText() == "\"");
        }

        [Fact]
        public void DoesNotContainControlChars()
        {
            var pattern = new String();
            Assert.False(pattern.Match(Quoted("a\nb\rc")).Success());
            Assert.True(pattern.Match(Quoted("a\nb\rc")).RemainingText() == Quoted("a\nb\rc"));
        }

        [Fact]
        public void CanContainEscapedQuotationMarks()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"\""a\"" b")).Success());
            Assert.True(pattern.Match(Quoted(@"\""a\"" b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedReverseSolidus()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \\ b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \\ b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedSolidus()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \/ b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \/ b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedBackspace()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \b b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \b b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedFormFeed()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \f b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \f b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedLineFeed()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \n b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \n b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedCarrigeReturn()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \r b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \r b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedHorizontalTab()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \t b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \t b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainEscapedUnicodeCharacters()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \u26Be b")).Success());
            Assert.True(pattern.Match(Quoted(@"a \u26Be b")).RemainingText() == "");
        }

        [Fact]
        public void CanContainLargeUnicodeCharacters()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted("⛅⚾")).Success());
            Assert.True(pattern.Match(Quoted("⛅⚾")).RemainingText() == "");
        }

        [Fact]
        public void DoesNotContainUnrecognizedEscapeChars()
        {
            var pattern = new String();
            Assert.False(pattern.Match(Quoted(@"a\x")).Success());
            Assert.True(pattern.Match(Quoted(@"a\x")).RemainingText() == Quoted(@"a\x"));
        }

        [Fact]
        public void DoesNotEndWithReverseSolidus()
        {
            var pattern = new String();
            Assert.False(pattern.Match(Quoted(@"a\")).Success());
            Assert.True(pattern.Match(Quoted(@"a\")).RemainingText() == Quoted(@"a\"));
        }

        [Fact]
        public void CanContainMultipleReverseSolidus()
        {
            var pattern = new String();
            Assert.True(pattern.Match(Quoted(@"a \\b c")).Success());
            Assert.True(pattern.Match(Quoted(@"a \\b c")).RemainingText() == "");
        }

        public static string Quoted(string text)
            => $"\"{text}\"";
    }
}
