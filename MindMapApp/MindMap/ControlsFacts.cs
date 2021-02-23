using System;
using System.Collections.Generic;
using Xunit;

namespace MindMap.Facts
{
    public class ControlsFacts
    {
        [Fact]
        public void InsertShouldAddAChildToCurrentNode()
        {
            var map = new Map();
            new Control(map).Insert();
            Assert.True(map.Current.Text == "new node"
                    && map.Current.Parent == map.CentralNode);
        }

        [Fact]
        public void EnterShouldNotAddASiblingToCentralNode()
        {
            var map = new Map();
            new Control(map).Enter();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void EnterShouldAddASiblingToCurrentNode()
        {
            var map = new Map();
            new Control(map).Insert("first");
            new Control(map).Enter("second");
            Assert.True(map.Current.Parent.Childs.Count == 2
                && map.Current.Parent.Childs[0].Text == "first"
                && map.Current.Parent.Childs[1].Text == "second");
        }

        [Fact]
        public void BackspaceShouldRemoveLastCharacterFromNodeText()
        {
            var map = new Map();
            new Control(map).Backspace();
            Assert.True(map.Current.Text == "central nod");
        }

        [Fact]
        public void UpArrowShouldNotChangeSelectionIfCurrentNodeHasNoSiblings()
        {
            var map = new Map();
            new Control(map).UpArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void UpArrowShouldChangeSelectionBetweenSiblings()
        {
            var map = new Map();
            new Control(map).Insert("first");
            new Control(map).Enter("second");
            new Control(map).UpArrow();
            Assert.True(map.Current.Text == "first");
        }

        [Fact]
        public void DownArrowShouldNotChangeSelectionIfCurrentNodeHasNoSiblings()
        {
            var map = new Map();
            new Control(map).DownArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void DownArrowShouldChangeSelectionBetweenSiblings()
        {
            var map = new Map();
            new Control(map).Insert("first");
            new Control(map).Enter("second");
            new Control(map).UpArrow();
            new Control(map).DownArrow();
            Assert.True(map.Current.Text == "second");
        }

        [Fact]
        public void LeftArrowShouldNotChangeSelectionIfCurrentNodeHasNoChilds()
        {
            var map = new Map();
            new Control(map).LeftArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void LeftArrowShouldChangeSelectionToCurrentNodeParent()
        {
            var map = new Map();
            new Control(map).Insert();
            new Control(map).LeftArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void RightArrowShouldNotChangeSelectionIfCurrentNodeHasNoChilds()
        {
            var map = new Map();
            new Control(map).RightArrow();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void RightArrowShouldChangeSelectionToCurrentNodeFirstChild()
        {
            var map = new Map();
            new Control(map).Insert();
            new Control(map).LeftArrow();
            new Control(map).RightArrow();
            Assert.True(map.Current.Text == "new node");
        }

        [Fact]
        public void DeleteShouldNotDeleteCurrentNodeIfItsCentralNode()
        {
            var map = new Map();
            new Control(map).Delete();
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void DeleteShouldDeleteCurrentNodeAndSetCurrentToNextSibling()
        {
            var map = new Map();
            new Control(map).Insert();
            new Control(map).Enter();
            new Control(map).Delete();
            Assert.True(map.Current.Text == "new node"
                    && map.Current.Parent.Childs.Count == 1);
        }

        [Fact]
        public void DeleteShouldDeleteCurrentNodeAndSetCurrentToCurrentNodeParentIfDoesNotHaveSiblings()
        {
            var map = new Map();
            new Control(map).Insert();
            new Control(map).Delete();
            Assert.True(map.Current.Text == "central node" && map.Current.Childs.Count == 0);
        }

        [Fact]
        public void ChangeNodeTextShouldAddGivenCharToNodeTextIfGivenKeyIsALetter()
        {
            var map = new Map();
            new Control(map).ChangeNodeText('X');
            Assert.Equal("central nodeX", map.Current.Text);
        }

        [Fact]
        public void ChangeNodeTextShouldAddGivenCharToNodeTextIfGivenKeyIsASymbol()
        {
            var map = new Map();
            new Control(map).ChangeNodeText('%');
            Assert.Equal("central node%", map.Current.Text);
        }

        [Fact]
        public void TabShouldChangeCollapsedPropertyToOppositeValueIfCurrentNodeHasChilds()
        {
            var map = new Map();
            new Control(map).Insert();
            new Control(map).LeftArrow();
            new Control(map).Tab();
            Assert.True(map.Current.Collapsed);
        }

        [Fact]
        public void TabShouldNotChangeCollapsedPropertyIfCurrentNodeDoesNotHaveChilds()
        {
            var map = new Map();
            new Control(map).Tab();
            Assert.False(map.Current.Collapsed);
        }
    }
}
