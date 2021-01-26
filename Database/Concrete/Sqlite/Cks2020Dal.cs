﻿using Database.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Database.Concrete.Sqlite
{
    public class Cks2020Dal : IBase<Cks2020>
    {
        SQLiteConnection connection;
        SQLiteDataReader dataReader;
        SQLiteCommand command;
        DatabaseDb database;
        public Cks2020Dal()
        {
            database = new DatabaseDb();

        }
        public int Add(Cks2020 Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);
                command.CommandText = "INSERT INTO Cks2020(DosyaNo, Tc,IsimSoyisim,BabaAdi,KoyMahalle,CepTelefonu,EvTelefonu,KayitTarihi) VALUES(@DosyaNo, @Tc,@IsimSoyisim,@BabaAdi,@KoyMahalle,@CepTelefonu,@EvTelefonu,@KayitTarihi)";
                command.Parameters.AddWithValue("@DosyaNo", Entity.DosyaNo);
                command.Parameters.AddWithValue("@Tc", Entity.Tc);
                command.Parameters.AddWithValue("@IsimSoyisim", Entity.IsimSoyisim);
                command.Parameters.AddWithValue("@BabaAdi", Entity.BabaAdi);
                command.Parameters.AddWithValue("@KoyMahalle", Entity.KoyMahalle);
                command.Parameters.AddWithValue("@CepTelefonu", Entity.CepTelefonu);
                command.Parameters.AddWithValue("@EvTelefonu", Entity.EvTelefonu);
                command.Parameters.AddWithValue("@KayitTarihi", Entity.KayitTarihi);
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

        public int Delete(Cks2020 Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);

                command.CommandText = "DELETE FROM Cks2020 WHERE Tc=@Tc";
                command.Parameters.AddWithValue("@Tc", Entity.Tc);
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

        public Cks2020 Get(string Tc)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Cks2020 Where Tc=@Tc";
                command.Parameters.AddWithValue("@Tc", Tc);
                connection.Open();
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    Cks2020 cks = new Cks2020();

                    while (dataReader.Read())
                    {
                        cks.Id = dataReader.GetInt32(0);
                        cks.DosyaNo = dataReader.GetInt32(1);
                        cks.Tc = dataReader.GetString(2);
                        cks.IsimSoyisim = dataReader.GetString(3);
                        cks.BabaAdi = dataReader.GetString(4);
                        cks.KoyMahalle = dataReader.GetString(5);
                        cks.CepTelefonu = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
                        cks.EvTelefonu = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        cks.KayitTarihi = dataReader.GetString(8);

                    }
                    return cks;
                }
                else
                {
                    return new Cks2020() { Tc="-1"};
                }

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

        public List<Cks2020> GetAll()
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                command = new SQLiteCommand(connection);
                command.CommandText = "SELECT * FROM Cks2020 ORDER BY DosyaNo DESC";
                connection.Open();
                dataReader = command.ExecuteReader();
                List<Cks2020> liste = new List<Cks2020>();
                while (dataReader.Read())
                {
                    Cks2020 cks = new Cks2020();
                    cks.Id = dataReader.GetInt32(0);
                    cks.DosyaNo = dataReader.GetInt32(1);
                    cks.Tc = dataReader.GetString(2);
                    cks.IsimSoyisim = dataReader.GetString(3);
                    cks.BabaAdi = dataReader.GetString(4);
                    cks.KoyMahalle = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6))
                    {
                        cks.CepTelefonu = dataReader.GetString(6);
                    }
                    if (!dataReader.IsDBNull(7))
                    {
                        cks.EvTelefonu = dataReader.GetString(7);
                    }


                    cks.KayitTarihi = dataReader.GetString(8);
                    liste.Add(cks);
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

        public int Update(Cks2020 Entity)
        {
            try
            {
                connection = new SQLiteConnection(database.ConnectionString);
                connection.Open();
                command = new SQLiteCommand(connection);

                command.CommandText = "UPDATE Cks2020 SET " +
                    "DosyaNo=@DosyaNo, Tc=@Tc, IsimSoyisim = @IsimSoyisim ," +
                    "BabaAdi=@BabaAdi ,KoyMahalle=@KoyMahalle ,CepTelefonu=@CepTelefonu ," +
                    "EvTelefonu=@EvTelefonu ,KayitTarihi=@KayitTarihi WHERE Id=@Id";
                command.Parameters.AddWithValue("@DosyaNo", Entity.DosyaNo);
                command.Parameters.AddWithValue("@Tc", Entity.Tc);
                command.Parameters.AddWithValue("@IsimSoyisim", Entity.IsimSoyisim);
                command.Parameters.AddWithValue("@BabaAdi", Entity.BabaAdi);
                command.Parameters.AddWithValue("@KoyMahalle", Entity.KoyMahalle);
                command.Parameters.AddWithValue("@CepTelefonu", Entity.CepTelefonu);
                command.Parameters.AddWithValue("@EvTelefonu", Entity.EvTelefonu);
                command.Parameters.AddWithValue("@KayitTarihi", Entity.KayitTarihi);
                command.Parameters.AddWithValue("@Id", Entity.Id);

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