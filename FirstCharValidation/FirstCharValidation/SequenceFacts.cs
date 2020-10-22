using Xunit;

namespace StringValidation.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void StringToCheckIsNullShouldReturnFalseAndRemainingTextNull()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Assert.False(sequence1.Match(null).Success());
            Assert.True(sequence1.Match(null).RemainingText() == null);
        }

        [Fact]
        public void StringToCheckIsEmptyShouldReturnFalseAndRemainingTextEmptyString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Assert.False(sequence1.Match("").Success());
            Assert.True(sequence1.Match("").RemainingText() == "");
        }

        [Fact]
        public void StringToCheckOnlyMatchesOnePatternShouldReturnFalseAndRemainingTextEntireString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Assert.False(sequence1.Match("ax").Success());
            Assert.True(sequence1.Match("ax").RemainingText() == "ax");
        }

        [Fact]
        public void StringToCheckDoesntMatchAllPatternsShouldReturnFalseAndRemainingTextEntireString()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            Assert.False(sequence2.Match("def").Success());
            Assert.True(sequence2.Match("def").RemainingText() == "def");
        }

        [Fact]
        public void StringToCheckMatchesAllSequencePatternsShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Assert.True(sequence1.Match("abcd").Success()
                && sequence1.Match("abcd").RemainingText() == "cd");
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingSequenceAsPatternShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            Assert.True(sequence2.Match("abcd").Success()
                && sequence2.Match("abcd").RemainingText() == "d");
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingMultipleSequencesAsPatternShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(new Character('d'), new Character('e'));
            Sequence sequence3 = new Sequence(sequence1, new Character('c'), sequence2);
            Assert.True(sequence3.Match("abcdef").Success()
                && sequence3.Match("abcdef").RemainingText() == "f");
        }

        [Fact]
        public void StringToCheckMatchesAllPatternsShouldReturnTrueAndRemainingTextEmptyString()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            Assert.True(hexSeq.Match("u1234").Success()
                && hexSeq.Match("u1234").RemainingText() == "");
        }

        [Fact]
        public void StringToCheckPartialyMatchesPatternsShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            Assert.True(hexSeq.Match("uabcdef").Success()
                && hexSeq.Match("uabcdef").RemainingText() == "ef");
        }

        [Fact]
        public void StringToCheckPartialyMatchesPatternsAndContainsWhiteSpaceShouldReturnTrueAndRemainingTextCharsNotMatched()
        {
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var hexSeq = new Sequence(new Character('u'), new Sequence(hex, hex, hex, hex));
            Assert.True(hexSeq.Match("uB005 ab").Success()
                && hexSeq.Match("uB005 ab").RemainingText() == " ab");
        }
    }
}