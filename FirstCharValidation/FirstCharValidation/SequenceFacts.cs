using Xunit;

namespace StringValidation.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void StringToCheckIsNullShouldReturnFalseAndRemainingTextNull()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            string stringToCheck = null;
            Assert.True(!sequence1.Match(stringToCheck).Success()
                && sequence1.Match(stringToCheck).RemainingText() == null);
        }

        [Fact]
        public void StringToCheckIsEmptyShouldReturnFalseAndRemainingTextEmptyString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            string stringToCheck = "";
            Assert.True(!sequence1.Match(stringToCheck).Success()
                && sequence1.Match(stringToCheck).RemainingText() == "");
        }

        [Fact]
        public void StringToCheckOnlyMatchesOnePatternShouldReturnFalseAndRemainingTextEntireString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            string stringToCheck = "ax";
            Assert.True(!sequence1.Match(stringToCheck).Success()
                && sequence1.Match(stringToCheck).RemainingText() == "ax");
        }

        [Fact]
        public void StringToCheckDoesntMatchAllPatternsShouldReturnFalseAndRemainingTextEntireString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            string stringToCheck = "def";
            Assert.True(!sequence2.Match(stringToCheck).Success()
                && sequence2.Match(stringToCheck).RemainingText() == "def");
        }

        [Fact]
        public void StringToCheckMatchesAllSequencePatternsShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            string stringToCheck = "abcd";
            Assert.True(sequence1.Match(stringToCheck).Success()
                && sequence1.Match(stringToCheck).RemainingText() == "cd");
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingSequenceAsPatternShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            string stringToCheck = "abcd";
            Assert.True(sequence2.Match(stringToCheck).Success()
                && sequence2.Match(stringToCheck).RemainingText() == "d");
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingMultipleSequencesAsPatternShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(new Character('d'), new Character('e'));
            Sequence sequence3 = new Sequence(sequence1, new Character('c'), sequence2);
            string stringToCheck = "abcdef";
            Assert.True(sequence3.Match(stringToCheck).Success()
                && sequence3.Match(stringToCheck).RemainingText() == "f");
        }

        [Fact]
        public void StringToCheckMatchesAllPatternsShouldReturnTrueAndRemainingTextEmptyString()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            string stringToCheck = "u1234";
            Assert.True(hexSeq.Match(stringToCheck).Success()
                && hexSeq.Match(stringToCheck).RemainingText() == "");
        }

        [Fact]
        public void StringToCheckPartialyMatchesPatternsShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            string stringToCheck = "uabcdef";
            Assert.True(hexSeq.Match(stringToCheck).Success()
                && hexSeq.Match(stringToCheck).RemainingText() == "ef");
        }

        [Fact]
        public void StringToCheckPartialyMatchesPatternsAndContainsWhiteSpaceShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            string stringToCheck = "uB005 ab";
            Assert.True(hexSeq.Match(stringToCheck).Success()
                && hexSeq.Match(stringToCheck).RemainingText() == " ab");
        }
    }
}