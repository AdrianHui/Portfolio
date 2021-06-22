using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace MindMap
{
    class SaveFile
    {
        private readonly string fileName;

        private readonly string content;

        public SaveFile(string fileName, string content, string path)
        {
            this.fileName = fileName;
            this.content = content;
            Path = path;
            Save();
        }

        public string Path { get; private set; }

        private void Save()
        {
            if (!File.Exists(Path))
            {
                Console.Clear();
                Console.WriteLine("Please enter file path: ");
                Path = Console.ReadLine() + "\\" + fileName;
                CreateFile();
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Path, false))
                {
                    sw.WriteLine(content);
                }
            }
        }

        private void CreateFile()
        {
            while (!File.Exists(Path))
            {
                try
                {
                    using (StreamWriter sw = File.CreateText(Path))
                    {
                        sw.WriteLine(content);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.Clear();
                    Console.WriteLine("The path you entered is not valid.");
                    Console.WriteLine("Please enter a valid file path: ");
                    Path = Console.ReadLine() + "\\" + fileName;
                }
                catch (ArgumentException)
                {
                    Console.Clear();
                    Console.WriteLine("The path you entered is not valid.");
                    Console.WriteLine("Please enter a valid file path: ");
                    Path = Console.ReadLine() + "\\" + fileName;
                }
                catch (DirectoryNotFoundException)
                {
                    Console.Clear();
                    Console.WriteLine("The path you entered is not valid.");
                    Console.WriteLine("Please enter a valid file path: ");
                    Path = Console.ReadLine() + "\\" + fileName;
                }
            }
        }
    }
}
