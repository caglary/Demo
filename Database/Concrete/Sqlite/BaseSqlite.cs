using Database.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
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
                connection = new SQLiteConnection(database.ConnectionString);
                command = new SQLiteCommand(connection);

                connection.Open();

                action.Invoke();
            }
            catch (Exception exception)
            {

                throw exception;

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
