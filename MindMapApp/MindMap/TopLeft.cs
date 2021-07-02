using System.Windows.Forms;

namespace MindMap
{
    class TopLeft
    {
        private readonly string title;

        private readonly Node centralNode;

        public TopLeft(string title, Node centralNode)
        {
            this.title = title;
            this.centralNode = centralNode;
        }

        public int CanvasWidth { get; private set; } = Screen.PrimaryScreen.Bounds.Width;

        public int CanvasHeight { get; private set; } = Screen.PrimaryScreen.Bounds.Height;

        public string GetFile()
        {
            string htmlFile = new HTML().DocType();
            string nodes = "";
            int y = 50;
            string svgNodes = GetMapNodes(centralNode, ref nodes, 10, ref y);
            htmlFile += new HTML().SetHTML(
                            new HTML().Head(
                                    new HTML().Title(title))
                            + new HTML().Body(
                                    new SVG().Create(CanvasWidth, CanvasHeight, svgNodes)));

            return htmlFile;
        }

        private string GetMapNodes(Node node, ref string result, int x, ref int y)
        {
            if (node == centralNode)
            {
                result += new SVG().Rectangle(x - 5, y - 20, node.Text.Length * 10);
                result += new SVG().Text(x, y, node.Text);
                x += 50;
                y += 50;
            }

            int siblingX = x;
            int siblingY = y;
            for (int i = 0; i < node.Childs.Count; i++)
            {
                result += new SVG().Rectangle(x - 9, y - 20, node.Childs[i].Text.Length * 10 + 10);
                result += new SVG().Text(x - 9, y, node.Childs[i].Text);
                result += new SVG().Line(siblingX - 20, siblingY - 45, x - 20, y - 10);
                result += new SVG().Line(x - 20, y - 10, x - 10, y - 10);
                y += 50;
                if (node.Childs[i].Childs.Count > 0)
                {
                    GetMapNodes(node.Childs[i], ref result, x + 50, ref y);
                }

                CanvasWidth = x < CanvasWidth ? CanvasWidth : x + node.Childs[i].Text.Length * 10 + 10;
                CanvasHeight = y < CanvasHeight ? CanvasHeight : y + 50;
            }

            return result;
        }
    }
}
