using Xunit;

namespace StringValidation.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void x()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Match match = new Match("abcd", sequence1);
            sequence1.Match("abcd");
            Assert.True(match.CheckParams(true, "cd"));
        }

        [Fact]
        public void z()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));
            Sequence sequence2 = new Sequence(sequence1, new Character('c'));
            sequence2.Match("abcd");
            Assert.True();
        }

        [Fact]
        public void y()
        {
            Sequence sequence1 = new Sequence(new Character('a'), new Character('b'));

            Assert.False(sequence1.Match("def").Success());
        }

    }
}
