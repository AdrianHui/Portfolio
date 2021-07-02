using System.Collections.Generic;

namespace MindMap
{
    class OpenedMaps : IMenu
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
