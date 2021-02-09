using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Utilities
{
    static class Logging
    {
        public static void Log(string text)
        {
            string path=Directory.GetCurrentDirectory();
            string name = DateTime.Now.ToShortDateString();
            name=name.Replace("/", "_");
            path = path + $"\\LogKayit";
            Directory.CreateDirectory(path);
            path = path + $"\\{name}.txt";
            if (!File.Exists(path))
                File.Create(path).Close();
            text = $"\n{DateTime.Now} -> {text}";
            File.AppendAllText(path,text);
        }
    }
}
