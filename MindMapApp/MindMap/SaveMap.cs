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
            SaveFile();
        }

        private void SaveFile()
        {
            if (!File.Exists(map.SavedMapFile))
            {
                Console.Clear();
                Console.WriteLine("Please enter file path: ");
                map.SavedMapFile = Console.ReadLine();
                CreateFile();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(map.SavedMapFile, false))
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

        private void CreateFile()
        {
            while (!File.Exists(map.SavedMapFile))
            {
                try
                {
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
                catch (UnauthorizedAccessException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid file path: ");
                    map.SavedMapFile = Console.ReadLine();
                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a valid file path: ");
                    map.SavedMapFile = Console.ReadLine();
                }
            }
        }
    }
}
