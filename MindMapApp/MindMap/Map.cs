using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MindMap
{
    class Map : IMenu
    {
        public Map()
        {
            Current = CentralNode;
            CurrentView = new MapCurrentView(this);
            Control = new MapControl(this);
        }

        public string Title { get; set; } = "New Map";

        public IList<string> FullMap { get; set; }

        public ICurrentView CurrentView { get; set; }

        public IControl Control { get; set; }

        public Node CentralNode { get; } = new Node("central node");

        public Node Current { get; set; }

        public string SavedMapFile { get; set; }

        public string Serialize()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            return JsonSerializer.Serialize(new SerializableMap(this), options);
        }

        internal Node GetNodeAbove(Node node)
        {
            if (node == CentralNode)
            {
                return node;
            }

            var index = Current.Parent.Childs.IndexOf(Current);
            var temp = index == 0 ? node.Parent : node.Parent.Childs[index - 1];
            if (index != 0 && Current.Parent.Childs[index - 1].Childs.Count > 0)
            {
                while (temp.Childs.Count != 0 && !temp.Collapsed)
                {
                    temp = temp.Childs.Last();
                }
            }

            return temp;
        }

        internal Node GetNodeBelow(Node node)
        {
            if (node == CentralNode && node.Childs.Count == 0)
            {
                return node;
            }

            while (node == node.Parent.Childs.Last()
                && node != CentralNode.Childs.Last())
            {
                node = node.Parent;
            }

            if (node.Childs.Count > 0 && node == node.Parent.Childs.Last())
            {
                return Current;
            }

            return node == node.Parent.Childs.Last()
                ? node
                : node.Parent.Childs[node.Parent.Childs.IndexOf(node) + 1];
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
                    ? (CurrentView.HelpMenuWidth + 4, 1)
                    : (CurrentView.HelpMenuWidth + 3
                        + collapsedNodeIndent.Length,
                        FullMap.Count);
        }
    }
}