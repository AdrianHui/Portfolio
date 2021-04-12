using System;
using Xunit;

namespace MindMap.Facts
{
    public class MapFacts
    {
        [Fact]
        public void CurrentShouldReturnCentralNodeIfNoNodeIsAddedToMap()
        {
            var map = new Map();
            Assert.Equal("central node", map.Current.Text);
        }

        [Fact]
        public void CurrentShouldReturnLastAddedNode()
        {
            var map = new Map();
            new MapControl(map).Insert();
            Assert.Equal("new node", map.Current.Text);
        }
    }
}