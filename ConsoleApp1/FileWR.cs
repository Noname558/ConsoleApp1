using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ConsoleApp1
{
    class FileWR
    {
        private string Path;

        public FileWR(string path)
        {
            Path = path;
        }
        public List<BModel> ReadF()
        {
            var fileExist = File.Exists(Path);
            if (!fileExist)
            {
                File.CreateText(Path).Dispose();
                return new List<BModel>();
            }
            using (var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<BModel>>(fileText);
            }
        }

        public void SaveF(List<BModel> list)
        {
            using (StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(list);
                writer.Write(output);
            }

        }
    }
}
