using Xunit;

namespace StringValidation.Facts
{
    public class ValueFacts
    {
        [Fact] 
        public void CanBeNull()
        {
            var value = new Value();
            Assert.True(value.Match("null").Success());
            Assert.True(value.Match("null").RemainingText() == "");
        }

        [Fact]
        public void CanBeTrue()
        {
            var value = new Value();
            Assert.True(value.Match("true").Success());
            Assert.True(value.Match("true").RemainingText() == "");
        }

        [Fact]
        public void CanBeFalse()
        {
            var value = new Value();
            Assert.True(value.Match("false").Success());
            Assert.True(value.Match("false").RemainingText() == "");
        }

        [Fact]
        public void CanBeAString()
        {
            var value = new Value();
            Assert.True(value.Match("\"abcd\"").Success());
            Assert.True(value.Match("\"abcd\"").RemainingText() == "");
        }

        [Fact]
        public void CanBeAFractionalNumber()
        {
            var value = new Value();
            Assert.True(value.Match("3.14").Success());
            Assert.True(value.Match("3.14").RemainingText() == "");
        }

        [Fact]
        public void CanBeANumber()
        {
            var value = new Value();
            Assert.True(value.Match("35").Success());
            Assert.True(value.Match("35").RemainingText() == "");
        }

        [Fact]
        public void CanBeAnEmptyArray()
        {
            var value = new Value();
            Assert.True(value.Match("[]").Success());
            Assert.True(value.Match("[]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainOnlyAWhiteSpace()
        {
            var value = new Value();
            Assert.True(value.Match("[ ]").Success());
            Assert.True(value.Match("[ ]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainOnlyALineFeed()
        {
            var value = new Value();
            Assert.True(value.Match("[\\n]").Success());
            Assert.True(value.Match("[\\n]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainOnlyAnHorizontalTab()
        {
            var value = new Value();
            Assert.True(value.Match("[\\t]").Success());
            Assert.True(value.Match("[\\t]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainOnlyAnCarriageReturn()
        {
            var value = new Value();
            Assert.True(value.Match("[\\r]").Success());
            Assert.True(value.Match("[\\r]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainElementsWithoutWhiteSpaces()
        {
            var value = new Value();
            Assert.True(value.Match("[\"1\",\"2\"]").Success());
            Assert.True(value.Match("[\"1\",\"2\"]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainElementsWithWhiteSpaces()
        {
            var value = new Value();
            Assert.True(value.Match("[ \"1\" , \"2\" ]").Success());
            Assert.True(value.Match("[ \"1\" , \"2\" ]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainOnlyOneElement()
        {
            var value = new Value();
            Assert.True(value.Match("[\"1\"]").Success());
            Assert.True(value.Match("[\"1\"]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainAnotherArrayElement()
        {
            var value = new Value();
            Assert.True(value.Match("[[\"ab\", \"cd\"], \"ef\"]").Success());
            Assert.True(value.Match("[[\"ab\", \"cd\"], \"ef\"]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanContainObjectElement()
        {
            var value = new Value();
            Assert.True(value.Match("[{\"ab\":\"12\"}, \"ef\"]").Success());
            Assert.True(value.Match("[{\"ab\":\"12\"}, \"ef\"]").RemainingText() == "");
        }

        [Fact]
        public void ArrayCanNotContainMembers()
        {
            var value = new Value();
            Assert.False(value.Match("[\"ab\":\"12\", \"ef\"]").Success());
            Assert.True(value.Match("[\"ab\":\"12\", \"ef\"]").RemainingText() == "[\"ab\":\"12\", \"ef\"]");
        }

        [Fact]
        public void CanBeAnEmptyObject()
        {
            var value = new Value();
            Assert.True(value.Match("{}").Success());
            Assert.True(value.Match("{}").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainOnlyAWhiteSpace()
        {
            var value = new Value();
            Assert.True(value.Match("{ }").Success());
            Assert.True(value.Match("{ }").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainOnlyALineFeed()
        {
            var value = new Value();
            Assert.True(value.Match("{\\n}").Success());
            Assert.True(value.Match("{\\n}").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainOnlyAnHorizontalTab()
        {
            var value = new Value();
            Assert.True(value.Match("{\\t}").Success());
            Assert.True(value.Match("{\\t}").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainOnlyACarriageReturn()
        {
            var value = new Value();
            Assert.True(value.Match("{\\r}").Success());
            Assert.True(value.Match("{\\r}").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainMembersWithoutWhiteSpaces()
        {
            var value = new Value();
            Assert.True(value.Match("{\"abc\":\"true\",\"def\":\"false\"}").Success());
            Assert.True(value.Match("{\"abc\":\"true\",\"def\":\"false\"}").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanContainMembersWithWhiteSpaces()
        {
            var value = new Value();
            Assert.True(value.Match("{ \"abc\" : \"true\" , \"def\" : \"false\" }").Success());
            Assert.True(value.Match("{ \"abc\" : \"true\" , \"def\" : \"false\" }").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanHaveArrayAsMemberValue()
        {
            var value = new Value();
            Assert.True(value.Match("{ \"abc\" : [\"123\", \"456\"], \"def\" : \"false\" }").Success());
            Assert.True(value.Match("{ \"abc\" : [\"123\", \"456\"], \"def\" : \"false\" }").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanHaveAnotherObjectAsMemberValue()
        {
            var value = new Value();
            Assert.True(value.Match("{ \"abc\" : {\"123\" : \"null\"}, \"def\" : \"false\" }").Success());
            Assert.True(value.Match("{ \"abc\" : {\"123\" : \"null\"}, \"def\" : \"false\" }").RemainingText() == "");
        }

        [Fact]
        public void ObjectCanNotContainElements()
        {
            var value = new Value();
            Assert.False(value.Match("{ \"abc\", \"false\" }").Success());
            Assert.True(value.Match("{ \"abc\", \"false\" }").RemainingText() == "{ \"abc\", \"false\" }");
        }
    }
}
