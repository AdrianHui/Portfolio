using System;
using System.Windows.Forms;

namespace MindMap
{
    class SVG
    {
        public SVG()
        {
        }

        public string Create(double width, double height, string text, double x = 0, double y = 0)
        {
            return $"\t<svg viewbox=\"{x} {y} {width} {height}\" width=\"{width}\" height=\"{height}\">{text}\n\t</svg>";
        }

        public string Text(
            double x, double y, string text)
        {
            return $"\n\t\t<text x=\"{x}\" y=\"{y}\" style=\"font: normal 20px arial\">{text}</text>";
        }

        public string Line(double x1, double y1, double x2, double y2)
        {
            return $"\n\t\t<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\"" +
                " stroke=\"black\" stroke-width=\"0.1%\"/>";
        }

        public string Rectangle(double x, double y, double width)
        {
            return $"\n\t\t<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"25\"" +
                " rx=\"5\" style=\"fill: gainsboro\"/>";
        }
    }
}
