using System;
using System.Collections.Generic;
using System.Linq;

namespace MindMap
{
    public class OpenedMaps : ApplicationViewCoordinates, IMenu
    {
        public OpenedMaps()
        {
            Maps = new List<Map>();
            Maps.Add(new Map());
            CurrentMap = Maps[0];
            CurrentView = new OpenedMapsCurrentView(this);
            Control = new OpenedMapsControl(this);
        }

        public ICurrentView CurrentView { get; set; }

        public IControl Control { get; set; }

        internal Map CurrentMap { get; set; }

        internal List<Map> Maps { get; }
    }
}
