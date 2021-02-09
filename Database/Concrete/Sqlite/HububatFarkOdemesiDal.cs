using Database.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;
namespace Database.Concrete.Sqlite
{
    public class HububatFarkOdemesiDal :BaseSqlite, IDatabase<HububatFarkOdemesi>
    {
        public int Add(HububatFarkOdemesi Entity)
        {
            _try(() =>
            {
                command.CommandText = "INSERT INTO HububatFarkOdemesi (CksId, FirmaId, UrunId, HububatDosyaNo, MuracaatTarihi, FaturaTarih, FaturaNo, Miktar, Fiyat, Tutar, Note) VALUES (@CksId, @FirmaId, @UrunId, @HububatDosyaNo, @MuracaatTarihi, @FaturaTarih, @FaturaNo, @Miktar, @Fiyat, @Tutar, @Note)";
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@FirmaId", Entity.FirmaId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@HububatDosyaNo", Entity.HububatDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@FaturaTarih", Entity.FaturaTarihi);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@Miktar", Entity.Miktar);
                command.Parameters.AddWithValue("@Tutar", Entity.Tutar);
                command.Parameters.AddWithValue("@Fiyat", Entity.Fiyat);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                int result = command.ExecuteNonQuery();
            });
            return result;
        }
        public int Delete(HububatFarkOdemesi Entity)
        {
            _try(() =>
            {
                command.CommandText = "DELETE FROM HububatFarkOdemesi WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public List<HububatFarkOdemesi> GetAll()
        {
            List<HububatFarkOdemesi> hububatList = new List<HububatFarkOdemesi>();
            _try(() =>
            {
                command.CommandText = "SELECT * FROM HububatFarkOdemesi ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        HububatFarkOdemesi hububat = new HububatFarkOdemesi();
                        hububat.Id = dataReader.GetInt32(0);
                        hububat.CksId = dataReader.GetInt32(1);
                        hububat.FirmaId = dataReader.GetInt32(2);
                        hububat.UrunId = dataReader.GetInt32(3);
                        hububat.HububatDosyaNo = dataReader.GetInt32(4);
                        hububat.MuracaatTarihi = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5);
                        hububat.FaturaTarihi = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
                        hububat.FaturaNo = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        hububat.Miktar = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        hububat.Fiyat = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        //hububat.Tutar = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        hububat.Not = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        hububatList.Add(hububat);
                    }
                }
            });
            return hububatList;
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
            DataTable dt = new DataTable();
            _try(() =>
            {
                string query = "SELECT HububatFarkOdemesi.Id, HububatFarkOdemesi.HububatDosyaNo, HububatFarkOdemesi.FaturaTarih, HububatFarkOdemesi.FaturaNo, Urunler.UrunAdi, HububatFarkOdemesi.Miktar, HububatFarkOdemesi.Fiyat, HububatFarkOdemesi.Tutar, HububatFarkOdemesi.MuracaatTarihi from HububatFarkOdemesi inner join Urunler on HububatFarkOdemesi.UrunId=Urunler.Id where CksId=@CksId";
                command.CommandText = query;
                command.Parameters.AddWithValue("@CksId", id);
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
            });
            return dt;
        }
        public int Update(HububatFarkOdemesi Entity)
        {
            _try(() =>
            {
                command.CommandText = "update HububatFarkOdemesi set CksId=@CksId, FirmaId=@FirmaId, UrunId=@UrunId, HububatDosyaNo=@HububatDosyaNo, MuracaatTarihi=@MuracaatTarihi, FaturaTarih=@FaturaTarih, FaturaNo=@FaturaNo, Miktar=@Miktar, Fiyat=@Fiyat, Tutar=@Tutar, Note=@Note where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@FirmaId", Entity.UrunId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@HububatDosyaNo", Entity.HububatDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@FaturaTarih", Entity.FaturaTarihi);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@Miktar", Entity.Miktar);
                command.Parameters.AddWithValue("@Fiyat", Entity.Fiyat);
                command.Parameters.AddWithValue("@Tutar", Entity.Tutar);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
    }
}
