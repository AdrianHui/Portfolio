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
            OpenMapDialog();
        }

        private void OpenMapDialog()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Dispose();
            if (openFile.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            dataFile = openFile.FileName;
            Map map = JsonConvert.DeserializeObject<Map>(File.ReadAllText(dataFile));
            maps.Maps.Add(map);
        }
    }
}
