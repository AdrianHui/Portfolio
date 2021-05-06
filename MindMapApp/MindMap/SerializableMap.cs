using System;
using System.Collections.Generic;
using System.Text;

namespace MindMap
{
    class SerializableMap
    {
        private readonly Map map;

        public SerializableMap(Map map)
        {
            this.map = map;
        }

        public string Title { get => map.Title; }

        public IList<string> FullMap { get => map.FullMap; }

        public ICurrentView CurrentView { get => map.CurrentView; }

        public SerializableNode CentralNode { get => new SerializableNode(map.CentralNode); }

        public string SavedMapFile { get => map.SavedMapFile; }
    }
}