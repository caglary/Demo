using Database.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Concrete.Sqlite
{
    public class CiftciDal : IBase<Ciftci>
    {
        SQLiteConnection connection;
        SQLiteDataReader dataReader;
        SQLiteCommand command;
        DatabaseDb database;
        public CiftciDal()
        {
            database = new DatabaseDb();

        }
        public int Add(Ciftci Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Ciftciler(TcKimlikNo,NameSurname,FatherName,MotherName,Birthday,DateOfDeath,Gender,MaritalStatus,MobilePhone,HomePhone,Email,City,Town,Village,Note) VALUES(@TcKimlikNo,@NameSurname,@FatherName,@MotherName,@Birthday,@DateOfDeath,@Gender,@MaritalStatus,@MobilePhone,@HomePhone,@Email,@City,@Town,@Village,@Note)";
                command.Parameters.AddWithValue("@TcKimlikNo", Entity.TcKimlikNo);
                command.Parameters.AddWithValue("@NameSurname", Entity.NameSurname);
                command.Parameters.AddWithValue("@FatherName", Entity.FatherName);
                command.Parameters.AddWithValue("@MotherName", Entity.MotherName);
                command.Parameters.AddWithValue("@Birthday", Entity.Birthday);
                command.Parameters.AddWithValue("@DateOfDeath", Entity.DateOfDeath);
                command.Parameters.AddWithValue("@Gender", Entity.Gender);
                command.Parameters.AddWithValue("@MaritalStatus", Entity.MaritalStatus);
                command.Parameters.AddWithValue("@MobilePhone", Entity.MobilePhone);
                command.Parameters.AddWithValue("@HomePhone", Entity.HomePhone);
                command.Parameters.AddWithValue("@Email", Entity.Email);
                command.Parameters.AddWithValue("@City", Entity.City);
                command.Parameters.AddWithValue("@Town", Entity.Town);
                command.Parameters.AddWithValue("@Village", Entity.Village);
                command.Parameters.AddWithValue("@Note", Entity.Note);

                command.Prepare();
                int result = command.ExecuteNonQuery();

                return result;
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

        public int Delete(Ciftci Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "DELETE FROM Ciftciler WHERE TcKimlikNo=@TcKimlikNo";
                command.Parameters.AddWithValue("@TcKimlikNo", Entity.TcKimlikNo);
                command.Prepare();
                int result = command.ExecuteNonQuery();

                return result;
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

        public Ciftci Get(string Tc)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Ciftciler WHERE TcKimlikNo=@TcKimlikNo";
                command.Parameters.AddWithValue("@TcKimlikNo", Tc);

                connection.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    Ciftci ciftci = new Ciftci();

                    while (dataReader.Read())
                    {
                        ciftci.TcKimlikNo = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1);
                        ciftci.NameSurname = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2);
                        ciftci.FatherName = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3);
                        ciftci.MotherName = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4);
                        ciftci.Birthday = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5);
                        ciftci.DateOfDeath = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
                        ciftci.Gender = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        ciftci.MaritalStatus = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        ciftci.MobilePhone = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        ciftci.HomePhone = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        ciftci.Email = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        ciftci.City = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);
                        ciftci.Town = dataReader.IsDBNull(13) ? "" : dataReader.GetString(13);
                        ciftci.Village = dataReader.IsDBNull(14) ? "" : dataReader.GetString(14);
                        ciftci.Note = dataReader.IsDBNull(15) ? "" : dataReader.GetString(15);


                    }
                    return ciftci;
                }
                else
                {
                    return new Ciftci();

                }

            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                connection.Close();
            };
        }

        public List<Ciftci> GetAll()
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Ciftciler ";
                connection.Open();
                dataReader = command.ExecuteReader();
                List<Ciftci> liste = new List<Ciftci>();
                if (dataReader.HasRows)
                {


                    while (dataReader.Read())
                    {
                        Ciftci ciftci = new Ciftci();
                        ciftci.TcKimlikNo = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1);
                        ciftci.NameSurname = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2);
                        ciftci.FatherName = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3);
                        ciftci.MotherName = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4);
                        ciftci.Birthday = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5);
                        ciftci.DateOfDeath = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
                        ciftci.Gender = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        ciftci.MaritalStatus = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        ciftci.MobilePhone = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        ciftci.HomePhone = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        ciftci.Email = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        ciftci.City = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);
                        ciftci.Town = dataReader.IsDBNull(13) ? "" : dataReader.GetString(13);
                        ciftci.Village = dataReader.IsDBNull(14) ? "" : dataReader.GetString(14);
                        ciftci.Note = dataReader.IsDBNull(15) ? "" : dataReader.GetString(15);
                        liste.Add(ciftci);

                    }
                }
                return liste;
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

        public int Update(Ciftci Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "UPDATE Ciftciler SET TcKimlikNo=@TcKimlikNo, NameSurname=@NameSurname,FatherName=@FatherName,MotherName=@MotherName,Birthday=@Birthday,DateOfDeath=@DateOfDeath,Gender=@Gender,MaritalStatus=@MaritalStatus,MobilePhone=@MobilePhone,HomePhone=@HomePhone,Email=@Email,City=@City,Town=@Town,Village=@Village,Note=@Note WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@TcKimlikNo", Entity.TcKimlikNo);
                command.Parameters.AddWithValue("@NameSurname", Entity.NameSurname);
                command.Parameters.AddWithValue("@FatherName", Entity.FatherName);
                command.Parameters.AddWithValue("@MotherName", Entity.MotherName);
                command.Parameters.AddWithValue("@Birthday", Entity.Birthday);
                command.Parameters.AddWithValue("@DateOfDeath", Entity.DateOfDeath);
                command.Parameters.AddWithValue("@Gender", Entity.Gender);
                command.Parameters.AddWithValue("@MarialStatus", Entity.MaritalStatus);
                command.Parameters.AddWithValue("@MobilePhone", Entity.MobilePhone);
                command.Parameters.AddWithValue("@HomePhone", Entity.HomePhone);
                command.Parameters.AddWithValue("@Email", Entity.Email);
                command.Parameters.AddWithValue("@City", Entity.City);
                command.Parameters.AddWithValue("@Town", Entity.Town);
                command.Parameters.AddWithValue("@Village", Entity.Village);
                command.Parameters.AddWithValue("@Note", Entity.Note);

                command.Prepare();
                int result = command.ExecuteNonQuery();

                return result;
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
