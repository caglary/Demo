using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Json
    {
        public static string SerializeObject<T>(IList<T> liste)
        {
            return JsonConvert.SerializeObject(liste);
        }
        public static List<T> DeserializeObject<T>(string seralized)
        {
            return JsonConvert.DeserializeObject<List<T>>(seralized);

        }

        public static void Backup<T>(List<T> list, string backupName, string _path = "")
        {
            string path = string.Empty;
            string serializeList = SerializeObject(list);
            if (string.IsNullOrEmpty(_path))
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                Directory.CreateDirectory(currentDirectory + @"\Backup");
                path = currentDirectory + @"\Backup\" + backupName + ".json";
                                
                if (!File.Exists(path))
                {
                    File.Create(path).Close();
                }
            }
            else
            {

                path = _path + @"\" + backupName + ".json";
                
            }

            File.WriteAllText(path, serializeList);

        }


    }
}
