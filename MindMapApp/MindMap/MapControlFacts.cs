using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MindMap.Facts
{
    public class MapControlFacts
    {
        [Fact]
        public void InsertShouldAddAChildToCurrentNode()
        {
            var map = new Map();
            new MapControl(map).Insert();
            Assert.True(map.Current.Text == "new node"
                    && map.Current.Parent == map.CentralNode);
        }

        [Fact]
        public void EnterShouldNotAddASiblingToCentralNode()
        {
            var map = new Map();
            new MapControl(map).Enter();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void EnterShouldAddASiblingToCurrentNode()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Enter();
            Assert.True(map.Current.Parent.Childs.Count == 2);
        }

        [Fact]
        public void BackspaceShouldRemoveLastCharacterFromNodeText()
        {
            var map = new Map();
            new MapControl(map).Backspace();
            Assert.True(map.Current.Text == "central nod");
        }

        [Fact]
        public void UpArrowShouldChangeSelectionBetweenSiblings()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Enter();
            new MapControl(map).UpArrow();
            Assert.True(map.Current == map.Current.Parent.Childs.First());
        }

        [Fact]
        public void UpArrowShouldChangeSelectionToPreviousSiblingLastChild()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Insert();
            new MapControl(map).UpArrow();
            new MapControl(map).Enter();
            new MapControl(map).UpArrow();
            Assert.True(map.Current == map.CentralNode.Childs.First().Childs.First());
        }

        [Fact]
        public void DownArrowShouldChangeSelectionBetweenSiblings()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Enter();
            new MapControl(map).UpArrow();
            new MapControl(map).DownArrow();
            Assert.True(map.Current == map.CentralNode.Childs.Last());
        }

        [Fact]
        public void DownArrowShouldChangeSelectionToCurrentNodeFirstChild()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).UpArrow();
            new MapControl(map).DownArrow();
            Assert.True(map.Current == map.CentralNode.Childs.First());
        }

        [Fact]
        public void DownArrowShouldChangeSelectionToTheNodeBelowEvenIfItsNotAChild()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Enter();
            new MapControl(map).UpArrow();
            new MapControl(map).Insert();
            new MapControl(map).DownArrow();
            Assert.True(map.Current == map.CentralNode.Childs.Last());
        }

        [Fact]
        public void LeftArrowShouldCollapseCurrentNodeIfItHasChilds()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).UpArrow();
            new MapControl(map).LeftArrow();
            Assert.True(map.Current.Collapsed);
        }

        [Fact]
        public void LeftArrowShouldNotCollapseCurrentNodeAndChangeSelectionToCurrentNodesParentIfItDoesNotHaveChilds()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).LeftArrow();
            Assert.False(map.Current.Collapsed && map.Current == map.CentralNode);
        }

        [Fact]
        public void LeftArrowShouldChangeSelectionToCurrentNodeParentIfNodeIsAlereadyCollapsed()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Insert();
            new MapControl(map).UpArrow();
            new MapControl(map).LeftArrow();
            new MapControl(map).LeftArrow();
            Assert.True(map.Current == map.CentralNode);
        }

        [Fact]
        public void RightArrowShouldNotChangeSelectionIfCurrentNodeHasNoChilds()
        {
            var map = new Map();
            new MapControl(map).RightArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void RightArrowShouldExpandCurrentNodeIfItIsCollapsed()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Insert();
            new MapControl(map).UpArrow();
            new MapControl(map).LeftArrow();
            new MapControl(map).RightArrow();
            Assert.False(map.Current.Collapsed);
        }

        [Fact]
        public void RightArrowShouldChangeSelectionToCurrentNodeFirstChildIfNodeIsNotCollapsed()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Insert();
            new MapControl(map).LeftArrow();
            new MapControl(map).RightArrow();
            Assert.True(map.Current.Parent == map.CentralNode.Childs.First());
        }

        [Fact]
        public void DeleteShouldNotDeleteCurrentNodeIfItsCentralNode()
        {
            var map = new Map();
            new MapControl(map).Delete();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void DeleteShouldDeleteCurrentNodeAndSetCurrentToNextSibling()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Enter();
            new MapControl(map).Delete();
            Assert.True(map.Current.Text == "new node"
                    && map.Current.Parent.Childs.Count == 1);
        }

        [Fact]
        public void DeleteShouldDeleteCurrentNodeAndSetCurrentToCurrentNodeParentIfDoesNotHaveSiblings()
        {
            var map = new Map();
            new MapControl(map).Insert();
            new MapControl(map).Delete();
            Assert.True(map.Current.Text == "central node" && map.Current.Childs.Count == 0);
        }

        [Fact]
        public void ChangeNodeTextShouldAddGivenCharToNodeTextIfGivenKeyIsALetter()
        {
            var map = new Map();
            new MapControl(map).ChangeText('X');
            Assert.Equal("central nodeX", map.Current.Text);
        }

        [Fact]
        public void ChangeNodeTextShouldAddGivenCharToNodeTextIfGivenKeyIsASymbol()
        {
            var map = new Map();
            new MapControl(map).ChangeText('%');
            Assert.Equal("central node%", map.Current.Text);
        }
    }
}