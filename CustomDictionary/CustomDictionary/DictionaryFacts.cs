using System;
using Xunit;

namespace CustomDictionary.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void AddMethodShouldAddTheElementAtSpecifiedKeyIndex()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.True(dict.Items[0].Key == 2 && dict.Items[0].Value == "a"
                && dict.Items[1].Key == 0 && dict.Items[1].Value == "b");
        }

        [Fact]
        public void AddMethodShouldAddTheElementAtSpecifiedKeyIndexAsFirstElementInBucket()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(7, "b");
            Assert.True(dict.Items[0].Key == 2 && dict.Items[1].Key == 7
                && dict.Items[1].Value == "b" && dict.Items[1].Next == 0);
        }

        [Fact]
        public void ContainsShouldReturnTrueIfGivenKeyIsFound()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.True(dict.ContainsKey(0));
        }

        [Fact]
        public void ContainsShouldReturnTrueIfGivenKeyIsInABucketWithMultipleElements()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "c");
            dict.Add(7, "b");
            Assert.True(dict.ContainsKey(2));
        }
    }
}
