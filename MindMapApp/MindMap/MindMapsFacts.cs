using System;
using System.Linq;
using Xunit;

namespace MindMap.Facts
{
    public class MindMapsFacts
    {
        [Fact]
        public void EditShouldAddANewMapIfInsertKeyIsPressedWhenOpenedMapsMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            Assert.True(maps.OpenedMaps.Maps.Count == 2);
        }

        [Fact]
        public void EditShouldAddANewChildToCurrentNodeIfInsertKeyIsPressedWhenMapMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 1);
        }

        [Fact]
        public void EditShouldAddANewSiblingToCurrentNodeIfEnterKeyIsPressedWhenMapMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 2);
        }

        [Fact]
        public void EditShouldDeleteCurrentMapIfDeleteKeyIsPressedWhenOpenedMapsMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false));
            Assert.True(maps.OpenedMaps.Maps.Count == 1);
        }

        [Fact]
        public void EditShouldDeleteCurrentNodeIfDeleteKeyIsPressedWhenMapMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Delete, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Childs.Count == 0);
        }

        [Fact]
        public void EditShouldRemoveCurrentMapTitleLastCharacterIfBackspaceKeyIsPressedWhenOpenedMapsMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Title == "New Ma");
        }

        [Fact]
        public void EditShouldRemoveCurrentNodeTextLastCharacterIfBackspaceKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.CentralNode.Text == "central nod");
        }

        [Fact]
        public void EditShouldSetCurrentMapToMapAboveIfUpArrowKeyIsPressedAndOpenedMapsMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap == maps.OpenedMaps.Maps.First());
        }

        [Fact]
        public void EditShouldSetCurrentNodeToPreviousSiblingIfUpArrowKeyIsPressedAndMapMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.First());
        }

        [Fact]
        public void EditShouldSetCurrentMapToBelowMapIfDownArrowKeyIsPressedAndOpenedMapsMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.DownArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap == maps.OpenedMaps.Maps.Last());
        }

        [Fact]
        public void EditShouldSetCurrentNodeToNextSiblingIfDownArrowKeyIsPressedAndMapMenuIsSelected()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.UpArrow, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.DownArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.Last());
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeParentIfLeftArrowIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current.Text == "central node");
        }

        [Fact]
        public void EditShouldSetCurrentNodeToCurrentNodeFirstChildIfRightArrowIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.Insert, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.LeftArrow, false, false, false));
            maps.Edit(new ConsoleKeyInfo('\0', ConsoleKey.RightArrow, false, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current
                == maps.OpenedMaps.CurrentMap.CentralNode.Childs.First());
        }

        [Fact]
        public void EditShouldAddTheCharToCurrentNodeTextIfAnyCharKeyIsPressed()
        {
            var maps = new MindMaps();
            maps.Edit(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
            maps.Edit(new ConsoleKeyInfo('X', ConsoleKey.X, true, false, false));
            Assert.True(maps.OpenedMaps.CurrentMap.Current.Text == "central nodeX");
        }
    }
}
