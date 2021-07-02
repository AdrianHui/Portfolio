using Xunit;

namespace MindMap.Facts
{
    public class HTMLFacts
    {
        [Fact]
        public void DocTypeShouldReturnHTMLDoctypeDeclaration()
        {
            var html = new HTML();
            Assert.Equal("<!DOCTYPE html>\n", html.DocType());
        }

        [Fact]
        public void SetHTMLShouldReturnGivenTextWrappedInHTMLTags()
        {
            var html = new HTML();
            Assert.Equal("<HTML>\ntest\n</HTML>\n", html.SetHTML("test"));
        }

        [Fact]
        public void HeadShouldReturnGivenTextWrappedInHeadTags()
        {
            var html = new HTML();
            Assert.Equal("<HEAD>\ntest\n</HEAD>\n", html.Head("test"));
        }

        [Fact]
        public void TitleShouldReturnGivenTextWrappedInTitleTags()
        {
            var html = new HTML();
            Assert.Equal("\t<TITLE>test</TITLE>\n", html.Title("test"));
        }

        [Fact]
        public void BodyShouldReturnGivenTextWrappedInBodyTags()
        {
            var html = new HTML();
            Assert.Equal("<BODY>\ntest\n</BODY>\n", html.Body("test"));
        }
    }
}
