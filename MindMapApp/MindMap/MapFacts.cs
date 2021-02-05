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
    }
}
