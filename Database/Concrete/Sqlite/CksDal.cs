using Database.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
namespace Database.Concrete.Sqlite
{
    public class CksDal : BaseSqlite, IDatabase<Cks>
    {
        public int Add(Cks Entity)
        {
            result = 0;
            _try(() =>
            {
                command.CommandText = "INSERT INTO Cks(DosyaNo, Tc,IsimSoyisim,BabaAdi,KoyMahalle,CepTelefonu,EvTelefonu,KayitTarihi) VALUES(@DosyaNo, @Tc,@IsimSoyisim,@BabaAdi,@KoyMahalle,@CepTelefonu,@EvTelefonu,@KayitTarihi)";
                command.Parameters.AddWithValue("@DosyaNo", Entity.DosyaNo);
                command.Parameters.AddWithValue("@Tc", Entity.Tc);
                command.Parameters.AddWithValue("@IsimSoyisim", Entity.IsimSoyisim);
                command.Parameters.AddWithValue("@BabaAdi", Entity.BabaAdi);
                command.Parameters.AddWithValue("@KoyMahalle", Entity.KoyMahalle);
                command.Parameters.AddWithValue("@CepTelefonu", Entity.CepTelefonu);
                command.Parameters.AddWithValue("@EvTelefonu", Entity.EvTelefonu);
                command.Parameters.AddWithValue("@KayitTarihi", Entity.KayitTarihi);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public int Delete(Cks Entity)
        {
            result = 0;
            _try(() =>
            {
                command.CommandText = "DELETE FROM Cks WHERE Tc=@Tc";
                command.Parameters.AddWithValue("@Tc", Entity.Tc);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public Cks Get(string Tc)
        {
            Cks cks = new Cks();
            _try(() =>
            {
                command.CommandText = "SELECT * FROM Cks Where Tc=@Tc";
                command.Parameters.AddWithValue("@Tc", Tc);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
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
                }
            });
            return cks;
        }
        public List<Cks> GetAll()
        {
            List<Cks> liste = new List<Cks>();
            _try(() =>
            {
                command.CommandText = "SELECT * FROM Cks ORDER BY DosyaNo DESC";
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Cks cks = new Cks();
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
            });
            return liste;
        }
        public DataTable GetAllByQuery(string query)
        {
            DataTable dt = new DataTable();
            _try(() =>
            {
                command.CommandText = query;
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
            });
            return dt;
        }
        public DataTable GetAllDataTable(int id)
        {
            throw new NotImplementedException();
        }
        public int Update(Cks Entity)
        {
            result = 0;
            _try(() =>
            {
                command.CommandText = "UPDATE Cks SET " +
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
                result = command.ExecuteNonQuery();
            });
            return result;
        }
    }
}

