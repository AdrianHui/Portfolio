using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MindMap
{
    class OpenMap
    {
        private readonly OpenedMaps maps;

        private string dataFile = "";

        public OpenMap(OpenedMaps maps)
        {
            this.maps = maps;
            OpenFile();
        }

        private void OpenFile()
        {
            while (!File.Exists(dataFile))
            {
                Console.Clear();
                Console.WriteLine("Please enter file path: ");
                dataFile = Console.ReadLine();
            }

            Map map = JsonConvert.DeserializeObject<Map>(File.ReadAllText(dataFile));
            SetParentReferences(map.CentralNode);
            maps.Maps.Add(map);
        }

        private void SetParentReferences(Node node)
        {
            for (int i = 0; i < node.Childs.Count; i++)
            {
                node.Childs[i].Parent = node;
                if (node.Childs[i].Childs.Count > 0)
                {
                    SetParentReferences(node.Childs[i]);
                }
            }
        }
    }
}
