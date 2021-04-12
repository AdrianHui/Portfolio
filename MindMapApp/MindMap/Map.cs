using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    class Map : ApplicationViewCoordinates, IMenu
    {
        public Map()
        {
            Current = CentralNode;
            CentralNode.Coordinates = (DefaultMapLeft, 1);
            CurrentView = new MapCurrentView(this);
            Control = new MapControl(this);
        }

        public string Title { get; set; } = "New Map";

        public ICurrentView CurrentView { get; set; }

        public IControl Control { get; set; }

        internal IList<string> FullMap { get; set; }

        internal Node CentralNode { get; } = new Node("central node");

        internal Node Current { get; set; }

        internal Node GetNodeAbove(Node node)
        {
            if (node == CentralNode)
            {
                return node;
            }

            var index = Current.Siblings.IndexOf(Current);
            var temp = index == 0 ? node.Parent : node.Siblings[index - 1];
            if (index != 0 && Current.Siblings[index - 1].Childs.Count > 0)
            {
                while (temp.Childs.Count != 0 && !temp.Collapsed)
                {
                    temp = temp.Childs.Last();
                }
            }

            return temp;
        }

        internal void Build(Node node, string indent = "   ")
        {
            if (node == CentralNode)
            {
                AddNode(node, indent);
            }

            for (int i = 0; i < node.Childs.Count && !node.Collapsed; i++)
            {
                AddNode(node.Childs[i], indent);
                if (node.Childs[i].Childs.Count > 0)
                {
                    var last = node.Childs[i] == node.Childs.Last();
                    Build(node.Childs[i], indent + (last ? "   " : "│  "));
                }
            }
        }

        private void AddNode(Node node, string indent)
        {
            string nodeText = node == Current
                                       ? $"\u001b[33m{node.Text}\u001b[0m"
                                       : node.Text;
            string collapsedNodeIndent = indent + (node.Collapsed ? "├>" : "├─");
            if (node == CentralNode)
            {
                FullMap.Add((node.Collapsed ? ">" : "─") + nodeText);
            }
            else
            {
                FullMap.Add(indent + "│");
                FullMap.Add(collapsedNodeIndent + nodeText);
            }

            node.Coordinates = node == CentralNode
                    ? (OpenedMapsMenuWidth + 4, 1)
                    : (OpenedMapsMenuWidth + 3
                        + collapsedNodeIndent.Length,
                        FullMap.Count);
        }
    }
}