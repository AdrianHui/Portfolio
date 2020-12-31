using System;
using Linq;
using Xunit;

namespace Linq.Facts
{
    public class LinqMethodsFacts
    {
        [Fact]
        public void ConsonantAndVowelCounterShouldReturnTheNumberOfConsonantsAndVowelsInGivenString()
        {
            var linq = new LinqMethods();
            var (vowels, consonants) = linq.ConsonantAndVowelCounter("test");
            Assert.True(vowels == 1 && consonants == 3);
        }

        [Fact]
        public void FirstUniqueCharacterShouldReturnFirstUniqueCharacterFromGivenString()
        {
            var linq = new LinqMethods();
            char result = linq.FirstUniqueCharacter("test");
            Assert.Equal('e', result);
        }

        [Fact]
        public void MostOccurencesShouldReturnTheCharacterWithMostOccurencesInGivenString()
        {
            var linq = new LinqMethods();
            var result = linq.MostOccurences("test");
            Assert.Equal('t', result);
        }
    }
}
