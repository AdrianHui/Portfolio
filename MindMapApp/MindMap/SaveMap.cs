using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace MindMap
{
    class SaveMap
    {
        private readonly Map map;

        public SaveMap(Map map)
        {
            this.map = map;
            SaveMapDialog();
        }

        private void SaveMapDialog()
        {
            if (!File.Exists(map.SavedMapFile))
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Dispose();
                if (saveDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                map.SavedMapFile = saveDialog.FileName;
            }

            using (StreamWriter sw = File.CreateText(map.SavedMapFile))
            {
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    WriteIndented = true
                };

                var serializedMap = JsonSerializer.Serialize(new SerializableMap(map), options);
                sw.WriteLine(serializedMap);
            }
        }
    }
}
