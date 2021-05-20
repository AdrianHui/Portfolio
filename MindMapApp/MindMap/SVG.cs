using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class SVG
    {
        public SVG()
        {
        }

        public string Create(int width, int height, string text)
        {
            return $"\t<svg width=\"{width}\" height=\"{height}\">{text}\n\t</svg>";
        }

        public string Text(int x, int y, string text)
        {
            return $"\n\t\t<text x=\"{x}\" y=\"{y}\" style=\"font: normal 20px arial\">{text}</text>";
        }

        public string Line(int x1, int y1, int x2, int y2)
        {
            return $"\n\t\t<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"black\" stroke-width=\"0.1%\"/>";
        }

        public string Rectangle(int x, int y, int width)
        {
            return $"\n\t\t<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"25\" rx=\"5\" style=\"fill: gainsboro\"/>";
        }
    }
}
