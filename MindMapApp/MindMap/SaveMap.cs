using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

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
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };

                var serializedMap = JsonSerializer.Serialize(new SerializableMap(map), options);
                sw.WriteLine(serializedMap);
            }
        }
    }
}
