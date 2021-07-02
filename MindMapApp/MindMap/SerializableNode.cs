using System.Collections.Generic;

namespace MindMap
{
    class SerializableNode
    {
        private readonly Node node;

        public SerializableNode(Node node)
        {
            this.node = node;
        }

        public string Text { get => node.Text; }

        public IList<SerializableNode> Childs
        {
            get => ConvertToSerializableNodeChilds(node.Childs);
        }

        public bool Collapsed { get => node.Collapsed; }

        private IList<SerializableNode> ConvertToSerializableNodeChilds(IList<Node> childs)
        {
            IList<SerializableNode> result = new List<SerializableNode>();
            for (int i = 0; i < childs.Count; i++)
            {
                result.Add(new SerializableNode(childs[i]));
                if (childs[i].Childs.Count > 0)
                {
                    ConvertToSerializableNodeChilds(childs[i].Childs);
                }
            }

            return result;
        }
    }
}
