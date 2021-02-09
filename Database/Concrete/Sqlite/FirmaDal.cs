using Database.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;
namespace Database.Concrete.Sqlite
{
    public class FirmaDal : BaseSqlite, IDatabase<Firma>
    {
        public int Add(Firma Entity)
        {
            _try(() =>
            {
                command.CommandText = "INSERT INTO Firmalar (FirmaAdi, VergiNumarasi, Note) VALUES (@FirmaAdi, @VergiNumarasi, @Note)";
                command.Parameters.AddWithValue("@FirmaAdi", Entity.FirmaAdi);
                command.Parameters.AddWithValue("@VergiNumarasi", Entity.VergiNo);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public int Delete(Firma Entity)
        {
            _try(() =>
            {
                command.CommandText = "DELETE FROM Firmalar WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public List<Firma> GetAll()
        {
            List<Firma> firmaList = new List<Firma>();
            _try(() =>
            {
                command.CommandText = "SELECT * FROM Firmalar ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Firma firma = new Firma();
                        firma.Id = dataReader.GetInt32(0);
                        firma.FirmaAdi = dataReader.IsDBNull(1) ? "" : dataReader.GetString(1);
                        firma.VergiNo = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2);
                        firma.Not = dataReader.IsDBNull(3) ? "" : dataReader.GetString(3);
                        firmaList.Add(firma);
                    }
                }
            });
            return firmaList;
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
            throw new System.NotImplementedException();
        }
        public int Update(Firma Entity)
        {
            _try(() =>
            {
                command.CommandText = "update Firmalar set FirmaAdi=@FirmaAdi, VergiNumarasi=@VergiNumarasi, Note=@Note where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@FirmaAdi", Entity.FirmaAdi);
                command.Parameters.AddWithValue("@VergiNumarasi", Entity.VergiNo);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
    }
}
