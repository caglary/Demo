using Database.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;
namespace Database.Concrete.Sqlite
{
    public class YemBitkileriDal : BaseSqlite, IDatabase<YemBitkileri>
    {
        public int Add(YemBitkileri Entity)
        {
            _try(() =>
            {
                command.CommandText = "INSERT INTO YemBitkileri (CksId, UrunId, YemDosyaNo, MuracaatTarihi, EkilisYili, AraziMahalleKoy, Ada, Parsel, MuracaatAlani, TespitEdilenAlan, KontrolTarihi, KontrolEdenler, Note) VALUES (@CksId, @UrunId, @YemDosyaNo, @MuracaatTarihi, @EkilisYili, @AraziMahalleKoy, @Ada, @Parsel, @MuracaatAlani, @TespitEdilenAlan, @KontrolTarihi, @KontrolEdenler, @Note)";
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@YemDosyaNo", Entity.YemDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@EkilisYili", Entity.EkilisYili);
                command.Parameters.AddWithValue("@AraziMahalleKoy", Entity.AraziMahalle);
                command.Parameters.AddWithValue("@Ada", Entity.Ada);
                command.Parameters.AddWithValue("@Parsel", Entity.Parsel);
                command.Parameters.AddWithValue("@MuracaatAlani", Entity.MuracaatAlani);
                command.Parameters.AddWithValue("@TespitEdilenAlan", Entity.TespitEdilenAlan);
                command.Parameters.AddWithValue("@KontrolTarihi", Entity.KontrolTarihi);
                command.Parameters.AddWithValue("@KontrolEdenler", Entity.KontrolEdenler);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                int result = command.ExecuteNonQuery();
            });
            return result;
        }
        public int Delete(YemBitkileri Entity)
        {
            _try(() =>
            {
                command.CommandText = "DELETE FROM YemBitkileri WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
        public List<YemBitkileri> GetAll()
        {
            List<YemBitkileri> yemList = new List<YemBitkileri>();
            _try(() =>
            {
                command.CommandText = "SELECT * FROM YemBitkileri ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        YemBitkileri yem = new YemBitkileri();
                        yem.Id = dataReader.GetInt32(0);
                        yem.CksId = dataReader.GetInt32(1);
                        yem.UrunId = dataReader.GetInt32(2);
                        yem.YemDosyaNo = dataReader.GetInt32(3);
                        yem.MuracaatTarihi = dataReader.IsDBNull(4) ? "" : dataReader.GetString(4);
                        yem.EkilisYili = dataReader.IsDBNull(5) ? "" : dataReader.GetString(5);
                        yem.AraziMahalle = dataReader.IsDBNull(6) ? "" : dataReader.GetString(6);
                        yem.Ada = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        yem.Parsel = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        yem.MuracaatAlani = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        yem.TespitEdilenAlan = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        yem.KontrolTarihi = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        yem.KontrolEdenler = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);
                        yem.Not = dataReader.IsDBNull(13) ? "" : dataReader.GetString(13);
                        yemList.Add(yem);
                    }
                }
            });
            return yemList;
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
        public DataTable GetAllDataTable(int Id)
        {
            DataTable dt = new DataTable();
            _try(() =>
            {
                command.CommandText = "SELECT YemBitkileri.Id, YemDosyaNo, UrunAdi, YemBitkileri.AraziMahalleKoy, Ada, Parsel, MuracaatAlani, MuracaatTarihi FROM YemBitkileri INNER JOIN Urunler on YemBitkileri.UrunId = Urunler.Id where  CksId=@CksId";
                command.Parameters.AddWithValue("@CksId", Id);
                dataReader = command.ExecuteReader();
                dt.Load(dataReader);
            });
            return dt;
        }
        public int Update(YemBitkileri Entity)
        {
            _try(() =>
            {
                command.CommandText = "update YemBitkileri set CksId=@CksId,UrunId=@UrunId, YemDosyaNo=@YemDosyaNo, MuracaatTarihi=@MuracaatTarihi, EkilisYili=@EkilisYili, AraziMahalleKoy=@AraziMahalleKoy, Ada=@Ada,Parsel=@Parsel, MuracaatAlani=@MuracaatAlani, TespitEdilenAlan=@TespitEdilenAlan, KontrolTarihi=@KontrolTarihi, KontrolEdenler=@KontrolEdenler, Note=@Note where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@YemDosyaNo", Entity.YemDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@EkilisYili", Entity.EkilisYili);
                command.Parameters.AddWithValue("@AraziMahalleKoy", Entity.AraziMahalle);
                command.Parameters.AddWithValue("@Ada", Entity.Ada);
                command.Parameters.AddWithValue("@Parsel", Entity.Parsel);
                command.Parameters.AddWithValue("@MuracaatAlani", Entity.MuracaatAlani);
                command.Parameters.AddWithValue("@TespitEdilenAlan", Entity.TespitEdilenAlan);
                command.Parameters.AddWithValue("@KontrolTarihi", Entity.KontrolTarihi);
                command.Parameters.AddWithValue("@KontrolEdenler", Entity.KontrolEdenler);
                command.Parameters.AddWithValue("@Note", Entity.Not);
                command.Prepare();
                result = command.ExecuteNonQuery();
            });
            return result;
        }
    }
}
