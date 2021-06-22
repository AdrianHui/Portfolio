using System;
using System.Linq;
using System.Windows.Forms;

namespace MindMap
{
    class Radial
    {
        private readonly string title;

        private readonly Node centralNode;

        public Radial(string title, Node centralNode)
        {
            this.title = title;
            this.centralNode = centralNode;
        }

        public double CanvasWidth { get; } = Screen.PrimaryScreen.Bounds.Width;

        public double CanvasHeight { get; } = Screen.PrimaryScreen.Bounds.Height;

        public double SVGx { get; private set; }

        public double SVGy { get; private set; }

        public double SVGWidth { get; private set; } = Screen.PrimaryScreen.Bounds.Width;

        public double SVGHeight { get; private set; } = Screen.PrimaryScreen.Bounds.Height;

        public string GetFile()
        {
            string htmlFile = new HTML().DocType();
            const double angle = 0;
            string result = GetMapNodes("", centralNode, CanvasWidth / 2, CanvasHeight / 2, angle);
            result += AddNode(0, 0, CanvasWidth / 2, CanvasHeight / 2, centralNode);
            htmlFile += new HTML().SetHTML(
                            new HTML().Head(
                                    new HTML().Title(title))
                            + new HTML().Body(
                                    new SVG().Create(SVGWidth, SVGHeight, result, SVGx, SVGy)));

            return htmlFile;
        }

        private string GetMapNodes(
            string result,
            Node node,
            double x,
            double y,
            double angle,
            double radius = 200,
            double step = 20)
        {
            double nodeCenterX = x;
            double nodeCenterY = y;
            for (int i = 0; i < node.Childs.Count; i++)
            {
                (double start, double end) = GetNodeStartAndEndAngles(node.Childs[i], angle, step);
                angle += !start.Equals(end) ? (end - step / 1.5 - start) / 2 : 0;
                (x, y) = GetCoordinates(CanvasWidth / 2, CanvasHeight / 2, angle, radius);
                if (node.Childs[i].Childs.Count > 0 && !node.Childs[i].Collapsed)
                {
                    result += GetMapNodes(
                        result, node.Childs[i], x, y, start, radius + 200, step / 1.5);
                }

                result += AddNode(nodeCenterX, nodeCenterY, x, y, node.Childs[i]);
                if (node.Childs[i] != node.Childs.Last()
                    && node.Childs[i + 1].Childs.Count < 3
                    && node.Childs[i].Childs.Count < 3)
                {
                    angle += node == centralNode
                    ? (360 - angle) / (node.Childs.Count - i)
                    : step;
                }
                else
                {
                    angle = end;
                }
            }

            AdjustView(x, y);
            return result;
        }

        private (double, double) GetNodeStartAndEndAngles(Node node, double angle, double step)
        {
            step /= 1.5;
            if (node.Childs.Count == 0)
            {
                return (angle, angle);
            }

            double endAngle = angle;
            for (int i = 0; i < node.Childs.Count; i++)
            {
                if (node.Childs[i].Childs.Count > 0)
                {
                    (double start, double end) = GetNodeStartAndEndAngles(node.Childs[i], endAngle, step / 1.5);
                    endAngle += end - start;
                }
                else
                {
                    endAngle += step;
                }
            }

            return (angle, endAngle);
        }

        private string AddNode(double x1, double y1, double x2, double y2, Node node)
        {
            string result = "";
            int nodePxLen = node.Text.Length * 10;
            if (node == centralNode)
            {
                result += new SVG().Rectangle(
                    CanvasWidth / 2 - nodePxLen / 2, CanvasHeight / 2 - 15, node.Text.Length * 10);
                result += new SVG().Text(CanvasWidth / 2 - nodePxLen / 2, CanvasHeight / 2 + 5, node.Text);
            }
            else
            {
                result += new SVG().Line(x1, y1, x2, y2);
                result += new SVG().Rectangle(
                 x2 - nodePxLen / 2, y2 - 15, node.Text.Length * 10 + 10);
                result += new SVG().Text(x2 - nodePxLen / 2, y2 + 5, node.Text);
            }

            return result;
        }

        private (double, double) GetCoordinates(double x, double y, double angle, double radius)
        {
            double degreeToRadians = angle * Math.PI / 180;
            return (x + radius * Math.Cos(degreeToRadians), y + radius * Math.Sin(degreeToRadians));
        }

        private void AdjustView(double x, double y)
        {
            if (x >= CanvasWidth || y >= CanvasHeight)
            {
                SVGWidth += 200;
                SVGHeight += 200;
            }
            else if (x < 0 || y < 0)
            {
                SVGx -= 200;
                SVGy -= 200;
                SVGWidth += 200;
                SVGHeight += 200;
            }
        }
    }
}
