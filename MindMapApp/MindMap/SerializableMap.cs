using System;

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

        public SerializableNode CentralNode { get => new SerializableNode(map.CentralNode); }
    }
}