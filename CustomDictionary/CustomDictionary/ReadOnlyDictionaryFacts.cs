using Xunit;
using System;
using System.Collections.Generic;

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

        [Fact]
        public void ValuesShouldReturnACollectionWithAllTheValues()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            var values = readOnlyDict.Values;
            Assert.True(values.Count == 2 && values.Contains("a") && values.Contains("b"));
        }

        [Fact]
        public void CountShouldReturnNumberOfElementsInTheCollection()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict.Count == 2);
        }

        [Fact]
        public void IsReadOnlyShouldReturnTrue()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict.IsReadOnly);
        }

        [Fact]
        public void GetterShouldGetTheValueAssociatedToGivenKey()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict[2] == "b");
        }

        [Fact]
        public void SetterShouldThrowAnException()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.Throws<NotSupportedException>(() => readOnlyDict[2] = "c");
        }

        [Fact]
        public void AddMethodShouldThrowAnExceptionWhenTryingToAddAKeyAndAValue()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.Throws<NotSupportedException>(() => readOnlyDict.Add(3, "c"));
        }

        [Fact]
        public void AddMethodShouldThrowAnExceptionWhenTryingToAddAKeyValuePair()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.Throws<NotSupportedException>(()
                => readOnlyDict.Add(new KeyValuePair<int, string>(3, "c")));
        }

        [Fact]
        public void ContainsKeyMethodShouldReturnTrueIfGivenKeyIsFound()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict.ContainsKey(0));
        }

        [Fact]
        public void ContainsKeyMethodShouldReturnFalseIfGivenKeyIsNotInABucket()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "c");
            dict.Add(7, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.False(readOnlyDict.ContainsKey(1));
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfGivenPairIsFound()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            dict.Add(first);
            dict.Add(second);
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict.Contains(first));
        }

        [Fact]
        public void ContainsMethodShouldReturnFalseIfGivenPairIsNotInABucket()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "c");
            var third = new KeyValuePair<int, string>(7, "b");
            dict.Add(first);
            dict.Add(second);
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.False(readOnlyDict.Contains(third));
        }

        [Fact]
        public void TryGetValueMethodShouldGetTheValueAssociatedtoGivenKey()
        {
            var dict = new Dictionary<int, string>(5);
            string b = "b";
            dict.Add(2, "a");
            dict.Add(0, b);
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.True(readOnlyDict.TryGetValue(0, out b));
        }

        [Fact]
        public void ClearMethodShouldThrowAnException()
        {
            var dict = new Dictionary<int, string>(2);
            dict.Add(1, "a");
            dict.Add(2, "b");
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            Assert.Throws<NotSupportedException>(() => readOnlyDict.Clear());
        }

        [Fact]
        public void CopyToMethodShouldCopyElementsToGivenArray()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            var arr = new KeyValuePair<int, string>[5];
            var readOnlyDict = new ReadOnlyDictionary<int, string>(dict);
            readOnlyDict.CopyTo(arr, 3);
            Assert.True(arr[3].Key == 2 && arr[3].Value == "a"
                && arr[4].Key == 0 && arr[4].Value == "b");
        }
    }
}
