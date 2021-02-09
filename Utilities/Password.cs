using System.IO;
namespace Utilities
{
    public class Password
    {
        private string _path;
        public static string incomigValue=string.Empty;
        public Password()
        {
            _path = Directory.GetCurrentDirectory() + @"\Password.json";
            if (!File.Exists(_path))
                File.Create(_path).Close();
        }
        public string GetPassword()
        {
            return File.ReadAllText(_path);
        }
    }
}
