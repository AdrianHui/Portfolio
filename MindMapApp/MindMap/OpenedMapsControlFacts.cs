using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MindMap.Facts
{
    public class OpenedMapsControlFacts
    {
        [Fact]
        public void InsertShouldAddNewMap()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Insert();
            Assert.True(maps.Maps.Count == 2);
        }

        [Fact]
        public void BackspaceShouldRemoveLastCharacterFromMapTitle()
        {
            var map = new Map();
            new MapControl(map).Backspace();
            Assert.True(map.Current.Text == "central nod");
        }

        [Fact]
        public void UpArrowShouldChangeSelectionBetweenSiblings()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Backspace();
            Assert.True(maps.CurrentMap.Title == "New Ma");
        }

        [Fact]
        public void UpArrowShouldChangeSelectionToMapAbove()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Insert();
            new OpenedMapsControl(maps).UpArrow();
            Assert.True(maps.CurrentMap == maps.Maps.First());
        }

        [Fact]
        public void DownArrowShouldChangeSelectionToMapBelow()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Insert();
            new OpenedMapsControl(maps).UpArrow();
            new OpenedMapsControl(maps).DownArrow();
            Assert.True(maps.CurrentMap == maps.Maps.Last());
        }

        [Fact]
        public void LeftArrowShouldMoveCurrentViewToLeftIfMapTitleIsLongerThanOpenedMapsMenuWidth()
        {
            var maps = new OpenedMaps();
            maps.CurrentView.Left = 5;
            new OpenedMapsControl(maps).LeftArrow();
            Assert.True(maps.CurrentView.Left == 4);
        }

        [Fact]
        public void RightArrowShouldNotChangeSelectionIfCurrentNodeHasNoChilds()
        {
            var maps = new OpenedMaps();
            maps.CurrentView.Left = 4;
            new OpenedMapsControl(maps).RightArrow();
            Assert.True(maps.CurrentView.Left == 5);
        }

        [Fact]
        public void DeleteShouldNotDeleteCurrentMapIfItsTheOnlyMap()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Delete();
            Assert.True(maps.Maps.Count == 1);
        }

        [Fact]
        public void DeleteShouldDeleteCurrentMapIfItsNotTheOnlyOne()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).Insert();
            new OpenedMapsControl(maps).Delete();
            Assert.True(maps.Maps.Count == 1);
        }

        [Fact]
        public void ChangeTextShouldAddGivenCharToMapTitleIfGivenKeyIsALetter()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).ChangeText('X');
            Assert.Equal("New MapX", maps.CurrentMap.Title);
        }

        [Fact]
        public void ChangeTextShouldAddGivenCharToMapTitleIfGivenKeyIsASymbol()
        {
            var maps = new OpenedMaps();
            new OpenedMapsControl(maps).ChangeText('%');
            Assert.Equal("New Map%", maps.CurrentMap.Title);
        }
    }
}
