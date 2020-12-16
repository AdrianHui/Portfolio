using Xunit;

namespace CustomDictionary.Facts
{
    public class ReadOnlyDictionaryFacts
    {
        [Fact]
        public void KeysShouldReturnACollectionWithAllTheKeys()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            var keys = readOnlyDict.Keys;
            Assert.True(keys.Count == 2 && keys.Contains(1) && keys.Contains(2));
        }
    }
}
