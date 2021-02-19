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
            new Control(map).Insert();
            Assert.Equal("new node", map.Current.Text);
        }

        [Fact]
        public void EditShouldAddANewChildToCurrentNodeIfInsertKeyIsPressed()
        {
            var map = new Map();
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            Assert.True(map.CentralNode.Childs.Count == 1
                && map.Current.Text == "new node");
        }

        [Fact]
        public void EditShouldAddANewSiblingToCurrentNodeIfEnterKeyIsPressed()
        {
            var map = new Map();
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            map.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            Assert.True(map.CentralNode.Childs.Count == 2);
        }

        [Fact]
        public void EditShouldDeleteCurrentNodeIfDeleteKeyIsPressed()
        {
            var map = new Map();
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false));
            Assert.True(map.CentralNode.Childs.Count == 0);
        }

        [Fact]
        public void EditShouldRemoveCurrentNodeTextLastCharacterIfBackspaceKeyIsPressed()
        {
            var map = new Map();
            map.Edit(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));
            Assert.True(map.CentralNode.Text == "central nod");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToPreviousSiblingIfUpArrowKeyIsPressed()
        {
            var map = new Map();
            new Control(map).Insert("first");
            new Control(map).Enter("second");
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            Assert.True(map.Current.Text == "first");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToNextSiblingIfDownArrowKeyIsPressed()
        {
            var map = new Map();
            new Control(map).Insert("first");
            new Control(map).Enter("second");
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.DownArrow, false, false, false));
            Assert.True(map.Current.Text == "second");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeParentIfLeftArrowIsPressed()
        {
            var map = new Map();
            new Control(map).Insert("first");
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            Assert.True(map.Current.Text == "central node");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeFirstChildIfRightArrowIsPressed()
        {
            var map = new Map();
            new Control(map).Insert("first");
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            map.Edit(new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, false, false, false));
            Assert.True(map.Current.Text == "first");
        }

        [Fact]
        public void EditShouldAddTheCharToCurrentNodeTextIfAnyCharKeyIsPressed()
        {
            var map = new Map();
            map.Edit(new ConsoleKeyInfo('X', ConsoleKey.X, true, false, false));
            Assert.True(map.Current.Text == "central nodeX");
        }
    }
}
