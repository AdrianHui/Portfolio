using Xunit;

namespace StringValidation.Facts
{
    public class CourseCodeValidatorFacts
    {
        [Fact]
        public void FirstThreeCharsCanBeAllUpercase()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("ABC5944").Success());
            Assert.True(pattern.Match("ABC5944").RemainingText() == "");
        }

        [Fact]
        public void FirstThreeCharsCanBeAllLowercase()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("abc5944").Success());
            Assert.True(pattern.Match("abc5944").RemainingText() == "");
        }

        [Fact]
        public void FirstThreeCharsCanBeAnyLetter()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("zHy5944").Success());
            Assert.True(pattern.Match("zHy5944").RemainingText() == "");
        }

        [Fact]
        public void FirstThreeCharsCanNotBeDigits()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("1235944").Success());
            Assert.True(pattern.Match("1235944").RemainingText() == "1235944");
        }

        [Fact]
        public void FirstThreeCharsCanNotBeSymbols()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("$@#5944").Success());
            Assert.True(pattern.Match("$@#5944").RemainingText() == "$@#5944");
        }

        [Fact]
        public void FourthCharCanNotBeEight()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("Abc8944").Success());
            Assert.True(pattern.Match("Abc8944").RemainingText() == "Abc8944");
        }

        [Fact]
        public void FourthCharCanBeAnyOtherEight()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("Abc7944").Success());
            Assert.True(pattern.Match("Abc7944").RemainingText() == "");
        }

        [Fact]
        public void FourthCharCanNotBeLetter()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("Abcd944").Success());
            Assert.True(pattern.Match("Abcd944").RemainingText() == "Abcd944");
        }

        [Fact]
        public void FifthCharCanNotBeLetter()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("Abc3z44").Success());
            Assert.True(pattern.Match("Abc3z44").RemainingText() == "Abc3z44");
        }

        [Fact]
        public void FifthCharCanNotBeZero()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("Abc3044").Success());
            Assert.True(pattern.Match("Abc3044").RemainingText() == "Abc3044");
        }

        [Fact]
        public void FifthCharCanBeAnyOtherDigit()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("Abc3544").Success());
            Assert.True(pattern.Match("Abc3544").RemainingText() == "");
        }

        [Fact]
        public void LastTwoCharsCanNotBeLetters()
        {
            var pattern = new CourseCodeValidator();
            Assert.False(pattern.Match("Abc35yz").Success());
            Assert.True(pattern.Match("Abc35yz").RemainingText() == "Abc35yz");
        }

        [Fact]
        public void LastTwoCharsCanBeAnyDigits()
        {
            var pattern = new CourseCodeValidator();
            Assert.True(pattern.Match("Abc3509").Success());
            Assert.True(pattern.Match("Abc3509").RemainingText() == "");
        }
    }
}
