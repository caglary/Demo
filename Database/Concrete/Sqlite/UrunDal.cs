using Database.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Concrete.Sqlite
{
    public class UrunDal : BaseSqlite, IDatabase<Urun>
    {
        public int Add(Urun Entity)
        {
            _try(() =>
            {

                command.CommandText = "INSERT INTO Urunler (UrunAdi) VALUES (@UrunAdi)";
                command.Parameters.AddWithValue("@UrunAdi", Entity.UrunAdi);
                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;
        }

        public int Delete(Urun Entity)
        {
            _try(() =>
            {
                command.CommandText = "DELETE FROM Urunler WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;
        }

        public List<Urun> GetAll()
        {
            List<Urun> productList = new List<Urun>();

            _try(() =>
            {

                command.CommandText = "SELECT * FROM Urunler ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        Urun product = new Urun();

                        product.Id = dataReader.GetInt32(0);
                        product.UrunAdi= dataReader.IsDBNull(1) ? "" : dataReader.GetString(1);
                        
                        productList.Add(product);

                    }

                }

            });
            return productList;
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

        public int Update(Urun Entity)
        {
            _try(() =>
            {
                command.CommandText = "update Urunler set UrunAdi=@UrunAdi where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@UrunAdi", Entity.UrunAdi);
                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;
        }
    }
}
