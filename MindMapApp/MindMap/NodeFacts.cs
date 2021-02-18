using System;
using Xunit;

namespace MindMap.Facts
{
    public class NodeFacts
    {
        [Fact]
        public void TextShouldReturnNodeText()
        {
            var node = new Node("node text");
            Assert.Equal("node text", node.Text);
        }

        [Fact]
        public void ParentShouldReturnCurrentNodeParent()
        {
            var node = new Node("node text");
            var parent = new Node("parent");
            node.Parent = parent;
            Assert.Equal(parent, node.Parent);
        }

        [Fact]
        public void ChildsShouldReturnAListWithAllNodeChilds()
        {
            var node = new Node("node text");
            var child1 = new Node("child");
            var child2 = new Node("child");
            node.Childs.Add(child1);
            node.Childs.Add(child2);
            Assert.Equal(new[] { child1, child2 }, node.Childs);
        }
    }
}
