using Xunit;

namespace StringValidation.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void x()
        {
            var sequence1 = new Sequence(new Character('a'), new Character('b'));
            var sequence2 = new Sequence(sequence1, new Character('c'));

            Assert.True(sequence2.Match("abcd").Success() == true &&
                sequence2.Match("abcd").RemainingText() == "d");
        }

    }
}
