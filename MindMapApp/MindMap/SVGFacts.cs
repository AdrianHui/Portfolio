using Xunit;

namespace MindMap.Facts
{
    public class SVGFacts
    {
        [Fact]
        public void CreateShouldReturnGivenTextWrappedInSVGTagsOfGivenWidthAndHeight()
        {
            var svg = new SVG();
            Assert.Equal("\t<svg viewbox=\"0 0 10 5\" width=\"10\" height=\"5\">test\n\t</svg>", svg.Create(10, 5, "test"));
        }

        [Fact]
        public void TextShouldReturnGivenTextWrappedInTextTagsAtGivenCoordinates()
        {
            var svg = new SVG();
            Assert.Equal(
                "\n\t\t<text x=\"0\" y=\"0\" style=\"font: normal 20px arial\">test</text>",
                svg.Text(0, 0, "test"));
        }

        [Fact]
        public void LineShouldReturnLineTagWithGivenCoordinates()
        {
            var svg = new SVG();
            Assert.Equal(
                "\n\t\t<line x1=\"1\" y1=\"2\" x2=\"3\" y2=\"4\" stroke=\"black\" stroke-width=\"0.1%\"/>",
                svg.Line(1, 2, 3, 4));
        }

        [Fact]
        public void RectangleShouldReturnRectangleTagWithGivenCoordinatesAndWidth()
        {
            var svg = new SVG();
            Assert.Equal(
                "\n\t\t<rect x=\"1\" y=\"2\" width=\"3\" height=\"25\" rx=\"5\" style=\"fill: gainsboro\"/>",
                svg.Rectangle(1, 2, 3));
        }
    }
}
