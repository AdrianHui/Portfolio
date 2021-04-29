using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MindMap
{
    class SaveMap
    {
        private readonly Map map;

        private string dataFile = "";

        public SaveMap(Map map)
        {
            this.map = map;
            SaveMapDialog();
        }

        private void SaveMapDialog()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Dispose();
            if (saveDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            dataFile = saveDialog.FileName;
            using (StreamWriter sw = File.CreateText(dataFile))
            {
                sw.WriteLine(JsonConvert.SerializeObject(map));
            }
        }
    }
}
