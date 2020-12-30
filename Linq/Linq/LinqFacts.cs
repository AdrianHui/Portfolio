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
    }
}
