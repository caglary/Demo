using Database.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Concrete.Sqlite
{
    public class BaseSqlite
    {

        SQLiteConnection connection;
        public SQLiteDataReader dataReader;
        public SQLiteCommand command;
        DatabaseDb database;
        public int result = 0;
        public BaseSqlite()
        {
            database = new DatabaseDb();

        }
        public void _try(Action action)
        {
            try
            {

                connection = new SQLiteConnection(database._connectionString);
                command = new SQLiteCommand(connection);

                connection.Open();

                action.Invoke();
            }
            catch (Exception exception)
            {
                Utilities.ErrorHandle._try(() => { throw exception; });
                //connectionstring dosyasını sil ve database tekrar göster
                //if (exception.HResult == -2147473489)
                //{
                //    System.Windows.Forms.MessageBox.Show("Kayıtlı bir Tc numarası veya dosya numarası ile kayıt yapmaya çalışıyorsunuz.");

                //}
                //else if (exception.HResult == -2146233033)
                //{
                //    System.Windows.Forms.MessageBox.Show("Form üzerinde eksik ya da yanlış bilgi girişi yaptınız.");

                //}
                //else
                //{
                //    //string _path = @".\connectionstring.txt";
                //    //File.Delete(_path);
                //    System.Windows.Forms.MessageBox.Show($"{exception.Message}  {exception.HResult}");
                //    //Environment.Exit(0);
                //}


            }
            finally
            {
                connection.Close();
            }
        }
    }
}
