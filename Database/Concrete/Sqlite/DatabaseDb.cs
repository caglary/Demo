
using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Database.Concrete.Sqlite
{
    public class DatabaseDb
    {
       
   
        public string ConnectionString = string.Empty;



        public string Path()
        {
            string _path = @".\connectionstring.txt";
            if (!File.Exists(_path))
            {
                using (FileStream fs = File.Create(_path))
                {
                   
                }
            }
            string connectionStringPath=File.ReadAllText(_path);
            return connectionStringPath;
        }
        public DatabaseDb()
        {
            string filePath=string.Empty;
            string path = Path();
            while (string.IsNullOrEmpty(path))
            {
               DialogResult dr= MessageBox.Show("Database için dosya seçmelisiniz. Devam etmek istiyor musunuz?","Database Bulunamadı...",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.No) Environment.Exit(0);
                
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    

                   
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //Get the path of specified file
                        filePath = openFileDialog.FileName;

                    }
                }
                File.WriteAllText(@".\connectionstring.txt", filePath);
                path = Path();

            }
            ConnectionString = $"Data Source={path}; version=3";
        }




    }
}
