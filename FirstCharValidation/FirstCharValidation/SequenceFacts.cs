using Xunit;

namespace StringValidation.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void StringToCheckMatchesAllSequencePatternsShouldReturnTrue()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            string stringToCheck = "abcd";
            Assert.True(sequence1.Match(stringToCheck).Success());
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingSequenceAsPatternShouldReturnTrue()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            string stringToCheck = "abcd";
            Assert.True(sequence2.Match(stringToCheck).Success());
        }

        [Fact]
        public void StringToCheckMatchesSequenceHavingMultipleSequencesAsPatternShouldReturnTrue()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(new Character('d'), new Character('e'));
            Sequence sequence3 = new Sequence(sequence1, new Character('c'), sequence2);
            string stringToCheck = "abcdef";
            Assert.True(sequence3.Match(stringToCheck).Success());
        }
    }
}