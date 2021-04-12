using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MindMap.Facts
{
    public class MindMapsFacts
    {
        [Fact]
        public void EditShouldAddANewChildToCurrentNodeIfInsertKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 1);
        }

        [Fact]
        public void EditaShouldAddANewSiblingToCurrentNodeIfEnterKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 2);
        }

        [Fact]
        public void EditShouldDeleteCurrentNodeIfDeleteKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 0);
        }

        [Fact]
        public void EditShouldRemoveCurrentNodeTextLastCharacterIfBackspaceKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Text == "central nod");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToPreviousSiblingIfUpArrowKeyIsPressed()
        {
            var maps = new MindMaps();
            new MapControl(maps.OpenedMaps.CurrentMap).Insert();
            new MapControl(maps.OpenedMaps.CurrentMap).Enter();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.First());
        }

        [Fact]
        public void EditShouldSetCurrentNodeToNextSiblingIfDownArrowKeyIsPressed()
        {
            var maps = new MindMaps();
            new MapControl(maps.OpenedMaps.CurrentMap).Insert();
            new MapControl(maps.OpenedMaps.CurrentMap).Enter();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.DownArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.Last());
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeParentIfLeftArrowIsPressed()
        {
            var maps = new MindMaps();
            new MapControl(maps.OpenedMaps.CurrentMap).Insert();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current.Text == "central node");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeFirstChildIfRightArrowIsPressed()
        {
            var maps = new MindMaps();
            new MapControl(maps.OpenedMaps.CurrentMap).Insert();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.First());
        }

        [Fact]
        public void EditShouldAddTheCharToCurrentNodeTextIfAnyCharKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('X', ConsoleKey.X, true, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current.Text == "central nodeX");
        }
    }
}
