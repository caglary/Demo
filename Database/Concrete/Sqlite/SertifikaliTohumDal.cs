using Database.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Data;

namespace Database.Concrete.Sqlite
{
    public class SertifikaliTohumDal : BaseSqlite, IDatabase<SertifikaliTohum>
    {

        public int Add(SertifikaliTohum Entity)
        {

            _try(() =>
            {
                command.CommandText = "INSERT INTO SertifikaliTohum (CksId, FirmaId, UrunId, SertifikaliDosyaNo, MuracaatTarihi, SertifikaNo, FaturaNo, FaturaTarihi, Miktari, BirimFiyati, ToplamMaliyet) VALUES (@CksId, @FirmaId, @UrunId, @SertifikaliDosyaNo , @MuracaatTarihi, @SertifikaNo, @FaturaNo, @FaturaTarihi, @Miktari, @BirimFiyati, @ToplamMaliyet)";
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@FirmaId", Entity.FirmaId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@SertifikaliDosyaNo", Entity.SertifikaliDosyaNo);

                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@SertifikaNo", Entity.SertifikaNo);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@FaturaTarihi", Entity.FaturaTarihi);
                command.Parameters.AddWithValue("@Miktari", Entity.Miktari);
                command.Parameters.AddWithValue("@BirimFiyati", Entity.BirimFiyati);
                command.Parameters.AddWithValue("@ToplamMaliyet", Entity.ToplamMaliyet);


                command.Prepare();
                int result = command.ExecuteNonQuery();

            });
            return result;

        }

        public int Delete(SertifikaliTohum Entity)
        {
            _try(() =>
            {
                command.CommandText = "DELETE FROM SertifikaliTohum WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;

        }



        public List<SertifikaliTohum> GetAll()
        {
            List<SertifikaliTohum> stList = new List<SertifikaliTohum>();

            _try(() =>
            {

                command.CommandText = "SELECT * FROM SertifikaliTohum ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        SertifikaliTohum st = new SertifikaliTohum();

                        st.Id = dataReader.GetInt32(0);
                        st.CksId = dataReader.GetInt32(1);
                        st.FirmaId = dataReader.GetInt32(2);
                        st.UrunId = dataReader.GetInt32(3);
                        st.SertifikaliDosyaNo = dataReader.GetInt32(4);
                        st.MuracaatTarihi = dataReader.GetString(5);
                        st.SertifikaNo = dataReader.GetString(6);
                        st.FaturaNo = dataReader.GetString(7);
                        st.FaturaTarihi = dataReader.GetString(8);
                        st.Miktari = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        st.BirimFiyati = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        //st.ToplamMaliyet = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        stList.Add(st);

                    }

                }

            });
            return stList;
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

        public DataTable GetAllDataTable(int CksId)
        {
            DataTable dt = new DataTable();

            _try(() =>
            {

                command.CommandText = "SELECT SertifikaliTohum.Id,SertifikaliTohum.SertifikaliDosyaNo, firmalar.FirmaAdi, Urunler.UrunAdi, SertifikaliTohum.Miktari, SertifikaliTohum.Note, SertifikaliTohum.MuracaatTarihi from   SertifikaliTohum inner join Cks on SertifikaliTohum.CksId = Cks.Id inner join Firmalar on SertifikaliTohum.FirmaId = Firmalar.Id inner join Urunler on SertifikaliTohum.UrunId = Urunler.Id where SertifikaliTohum.CksId = @CksId";
                command.Parameters.AddWithValue("@CksId", CksId);
                dataReader = command.ExecuteReader();

                dt.Load(dataReader);

            });
            return dt;
        }

        public int Update(SertifikaliTohum Entity)
        {
            _try(() =>
            {
                command.CommandText = "update SertifikaliTohum set CksId=@CksId, FirmaId=@FirmaId, UrunId=@UrunId, SertifikaliDosyaNo=@SertifikaliDosyaNo, MuracaatTarihi=@MuracaatTarihi, SertifikaNo=@SertifikaNo, FaturaNo=@FaturaNo, FaturaTarihi=@FaturaTarihi, Miktari=@Miktari, BirimFiyati=@BirimFiyati, ToplamMaliyet=@ToplamMaliyet, Note=@Note where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@FirmaId", Entity.FirmaId);
                command.Parameters.AddWithValue("@UrunId", Entity.UrunId);
                command.Parameters.AddWithValue("@SertifikaliDosyaNo", Entity.SertifikaliDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@SertifikaNo", Entity.SertifikaNo);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@FaturaTarihi", Entity.FaturaTarihi);

                command.Parameters.AddWithValue("@Miktari", Entity.Miktari);
                command.Parameters.AddWithValue("@BirimFiyati", Entity.BirimFiyati);
                command.Parameters.AddWithValue("@ToplamMaliyet", Entity.ToplamMaliyet);
                command.Parameters.AddWithValue("@Note", Entity.Not);


                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;
        }



    }
}
