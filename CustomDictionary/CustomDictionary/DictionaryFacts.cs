using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CustomDictionary.Facts
{
    public class DictionaryFacts
    {
        [Fact]
        public void AddMethodShouldAddTheElementToTheCollection()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(1, "a");
            dict.Add(0, "b");
            Assert.True(dict[1] == "a" && dict[0] == "b");
        }

        [Fact]
        public void AddMethodShouldThrowAnExceptionIfKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            Assert.Throws<ArgumentNullException>(() => dict.Add(null, "a"));
        }

        [Fact]
        public void AddMethodShouldThrowAnExceptionIfKeyAlreadyExists()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("a", "-a");
            Assert.Throws<ArgumentException>(() => dict.Add("a", "b"));
        }

        [Fact]
        public void ContainsKeyMethodShouldReturnTrueIfGivenKeyIsFound()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.True(dict.ContainsKey(0));
        }

        [Fact]
        public void ContainsKeyMethodShouldReturnTrueIfGivenKeyIsInABucketWithMultipleElements()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "c");
            dict.Add(7, "b");
            Assert.True(dict.ContainsKey(2));
        }

        [Fact]
        public void ContainsKeyMethodShouldReturnFalseIfGivenKeyIsNotInABucket()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "c");
            dict.Add(7, "b");
            Assert.False(dict.ContainsKey(3598));
        }

        [Fact]
        public void ContainsKeyMethodShouldThrowAnExceptionIfGivenKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("2", "a");
            dict.Add("0", "c");
            dict.Add("7", "b");
            Assert.Throws<ArgumentNullException>(() => dict.ContainsKey(null));
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfGivenPairIsFound()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            dict.Add(first);
            dict.Add(second);
            Assert.True(dict.Contains(first));
        }

        [Fact]
        public void ContainsMethodShouldReturnTrueIfGivenPairIsInABucketWithMultipleElements()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "c");
            var third = new KeyValuePair<int, string>(7, "b");
            dict.Add(first);
            dict.Add(second);
            dict.Add(third);
            Assert.True(dict.Contains(first));
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
            Assert.False(dict.Contains(third));
        }

        [Fact]
        public void RemoveMethodShouldReturnTrueAndRemoveElementWithGivenKeyIfIsFirstInOneOfTheBuckets()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            dict.Add(first);
            dict.Add(second);
            dict.Remove(0);
            var keys = dict.Keys;
            Assert.True(keys.Count == 1 && keys.Contains(2));
        }

        [Fact]
        public void RemoveMethodShouldReturnFalseIfElementWithGivenKeyIsNotInOneOfTheBuckets()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            dict.Add(first);
            dict.Add(second);
            Assert.False(dict.Remove(1));
        }

        [Fact]
        public void RemoveMethodShouldReturnTrueAndRemoveElementWithGivenKeyIfIsInOneOfTheBucketsButNotFirst()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            var third = new KeyValuePair<int, string>(7, "c");
            dict.Add(first);
            dict.Add(second);
            dict.Add(third);
            dict.Remove(2);
            var keys = dict.Keys;
            Assert.True(keys.Count == 2 && keys.Contains(0) && keys.Contains(7));
        }

        [Fact]
        public void RemoveMethodShouldThrowAnExceptionIfGivenKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("2", "a");
            dict.Add("0", "c");
            dict.Add("7", "b");
            Assert.Throws<ArgumentNullException>(() => dict.Remove(null));
        }

        [Fact]
        public void RemoveMethodShouldReturnTrueAndRemoveGivenElementIfIsFirstInOneOfTheBuckets()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            dict.Add(first);
            dict.Add(second);
            dict.Remove(second);
            var keys = dict.Keys;
            Assert.True(keys.Count == 1 && keys.Contains(2));
        }

        [Fact]
        public void RemoveMethodShouldReturnFalseIfGivenElementIsNotInOneOfTheBuckets()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            var third = new KeyValuePair<int, string>(1, "c");
            dict.Add(first);
            dict.Add(second);
            Assert.False(dict.Remove(third));
        }

        [Fact]
        public void RemoveMethodShouldReturnTrueAndRemoveGivenElementIfIsInOneOfTheBucketsButNotFirst()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            var second = new KeyValuePair<int, string>(0, "b");
            var third = new KeyValuePair<int, string>(7, "b");
            dict.Add(first);
            dict.Add(second);
            dict.Add(third);
            dict.Remove(first);
            var keys = dict.Keys;
            Assert.True(keys.Count == 2 && keys.Contains(0) && keys.Contains(7));
        }

        [Fact]
        public void AddMethodShouldAddTheElementAtFirstEmptyPosition()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(7, "b");
            dict.Add(0, "c");
            dict.Remove(7);
            dict.Add(5, "d");
            var keys = dict.Keys;
            Assert.True(keys.Count == 3 && keys.Contains(2)
                && keys.Contains(0) && keys.Contains(5));
        }

        [Fact]
        public void ClearMethodShouldResetCountAndRemoveAllItemsAndBuckets()
        {
            var dict = new Dictionary<int, string>(5);
            var first = new KeyValuePair<int, string>(2, "a");
            dict.Add(first);
            dict.Clear();
            var keys = dict.Keys;
            var values = dict.Values;
            Assert.True(keys.Count == 0 && values.Count == 0 && dict.Count == 0);
        }

        [Fact]
        public void TryGetValueMethodShouldGetTheValueAssociatedtoGivenKey()
        {
            var dict = new Dictionary<int, string>(5);
            string value;
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.True(dict.TryGetValue(0, out value) && value == "b");
        }

        [Fact]
        public void TryGetValueMethodShouldReturnFalseIfGivenKeyIsNotInTheCollection()
        {
            var dict = new Dictionary<int, string>(5);
            string value;
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.False(dict.TryGetValue(5, out value));
        }

        [Fact]
        public void TryGetValueMethodShouldThrowAnExceptionIfGivenKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            string value;
            var first = new KeyValuePair<string, string>("2", "a");
            var second = new KeyValuePair<string, string>("0", "b");
            var third = new KeyValuePair<string, string>("7", "c");
            dict.Add(first);
            dict.Add(second);
            dict.Add(third);
            Assert.Throws<ArgumentNullException>(() => dict.TryGetValue(null, out value));
        }

        [Fact]
        public void CopyToMethodShouldCopyElementsToGivenArray()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            var arr = new KeyValuePair<int, string>[5];
            dict.CopyTo(arr, 3);
            Assert.True(arr[3].Key == 0 && arr[3].Value == "b"
                && arr[4].Key == 2 && arr[4].Value == "a");
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfArrayIsNull()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            KeyValuePair<int, string>[] arr = null;
            Assert.Throws<ArgumentNullException>(() => dict.CopyTo(arr, 3));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfArrayIndexIsNegative()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            var arr = new KeyValuePair<int, string>[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => dict.CopyTo(arr, -3));
        }

        [Fact]
        public void CopyToMethodShouldThrowAnExceptionIfArrayDoseNotHaveEnoughEmptySlots()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            var arr = new KeyValuePair<int, string>[5];
            Assert.Throws<ArgumentException>(() => dict.CopyTo(arr, 4));
        }

        [Fact]
        public void GetterShouldReturnTheValueAssociatedToGivenKey()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            Assert.True(dict[2] == "a" && dict[0] == "b");
        }

        [Fact]
        public void GetterShouldThrowAnExceptionIfGivenKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("a", "-a");
            dict.Add("b", "-b");
            Assert.Throws<ArgumentNullException>(() => dict[null] == "-a");
        }

        [Fact]
        public void GetterShouldThrowAnExceptionIfGivenKeyCouldNotBeFound()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("a", "-a");
            dict.Add("b", "-b");
            Assert.Throws<KeyNotFoundException>(() => dict["c"] == "-c");
        }

        [Fact]
        public void SetterShouldReplaceTheValueAssociatedToGivenKeyWithGivenValue()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
#pragma warning disable S4143 // Collection elements should not be replaced unconditionally
            dict[0] = "c";
#pragma warning restore S4143 // Collection elements should not be replaced unconditionally
            Assert.True(dict[0] == "c");
        }

        [Fact]
        public void SetterShouldThrowAnExceptionIfGivenKeyIsNull()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("a", "-a");
            dict.Add("b", "-b");
            Assert.Throws<ArgumentNullException>(() => dict[null] = "-a");
        }

        [Fact]
        public void SetterShouldThrowAnExceptionIfGivenKeyCouldNotBeFound()
        {
            var dict = new Dictionary<string, string>(5);
            dict.Add("a", "-a");
            dict.Add("b", "-b");
            Assert.Throws<KeyNotFoundException>(() => dict["c"] = "-c");
        }

        [Fact]
        public void KeysMethodShouldReturnACollectionContainingAllTheKeys()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            dict.Add(7, "c");
            var keys = dict.Keys;
            Assert.True(keys.Contains(2) && keys.Contains(0) && keys.Contains(7));
        }

        [Fact]
        public void ValuesMethodShouldReturnACollectionContainingAllTheValues()
        {
            var dict = new Dictionary<int, string>(5);
            dict.Add(2, "a");
            dict.Add(0, "b");
            dict.Add(7, "c");
            var values = dict.Values;
            Assert.True(values.Contains("a") && values.Contains("b") && values.Contains("c"));
        }
    }
}
