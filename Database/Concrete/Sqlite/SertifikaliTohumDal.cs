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
    public class SertifikaliTohumDal : IBase<SertifikaliTohum>
    {
        SQLiteConnection connection;
        SQLiteDataReader dataReader;
        SQLiteCommand command;
        DatabaseDb database;
        private int result = 0;
        public SertifikaliTohumDal()
        {
            database = new DatabaseDb();
        }
        public int Add(SertifikaliTohum Entity)
        {

            _try(() =>
            {
                command.CommandText = "INSERT INTO SertifikaliTohum (CksId,SertifikaliDosyaNo,MuracaatTarihi,SertifikaNo,FaturaNo,FaturaTarihi,FirmaAdi,Urun,UrunCesidi,Miktari,BirimFiyati,ToplamMaliyet) VALUES (@CksId,@SertifikaliDosyaNo,@MuracaatTarihi,@SertifikaNo,@FaturaNo,@FaturaTarihi,@FirmaAdi,@Urun,@UrunCesidi,@Miktari,@BirimFiyati,@ToplamMaliyet)";
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@SertifikaliDosyaNo", Entity.SertifikaliDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@SertifikaNo", Entity.SertifikaNo);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@FaturaTarihi", Entity.FaturaTarihi);
                command.Parameters.AddWithValue("@FirmaAdi", Entity.FirmaAdi);
                command.Parameters.AddWithValue("@Urun", Entity.Urun);
                command.Parameters.AddWithValue("@UrunCesidi", Entity.UrunCesidi);
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

        public List<SertifikaliTohum> Get(string Tc)
        {
            List<SertifikaliTohum> stList = new List<SertifikaliTohum>();

            _try(() =>
            {
                command.CommandText = "SELECT* FROM Cks Where Tc = @Tc";
                command.Parameters.AddWithValue("@Tc", Tc);
                dataReader = command.ExecuteReader();
                int cksId = 0;
                if (dataReader.HasRows)
                {
                    Cks cks = new Cks();

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
                    cksId = cks.Id;
                }
                dataReader.Close();
                command.CommandText = "SELECT * FROM SertifikaliTohum WHERE CksId=@CksId";

                command.Parameters.AddWithValue("@CksId", cksId);
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {

                    while (dataReader.Read())
                    {
                        SertifikaliTohum st = new SertifikaliTohum();

                        st.Id = dataReader.GetInt32(0);
                        st.CksId = dataReader.GetInt32(1);
                        st.SertifikaliDosyaNo = dataReader.GetInt32(2);
                        st.MuracaatTarihi = dataReader.GetString(3);
                        st.SertifikaNo = dataReader.GetString(4);
                        st.FaturaNo = dataReader.GetString(5);
                        st.FaturaTarihi = dataReader.GetString(6);
                        st.FirmaAdi = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        st.Urun = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        st.UrunCesidi = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        st.Miktari = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        st.BirimFiyati = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        st.ToplamMaliyet = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);
                        stList.Add(st);


                    }

                }

            });
            return stList;

        }
        public SertifikaliTohum GetById(int Id)
        {
            SertifikaliTohum st = new SertifikaliTohum();
            _try(() =>
            {
                command.CommandText = "select * FROM SertifikaliTohum WHERE Id=@Id";
                command.Parameters.AddWithValue("@Id", Id);
                command.Prepare();
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        st.Id = dataReader.GetInt32(0);
                        st.CksId = dataReader.GetInt32(1);
                        st.SertifikaliDosyaNo = dataReader.GetInt32(2);
                        st.MuracaatTarihi = dataReader.GetString(3);
                        st.SertifikaNo = dataReader.GetString(4);
                        st.FaturaNo = dataReader.GetString(5);
                        st.FaturaTarihi = dataReader.GetString(6);
                        st.FirmaAdi = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        st.Urun = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        st.UrunCesidi = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        st.Miktari = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        st.BirimFiyati = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        st.ToplamMaliyet = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);



                    }

                }
            });
        
            return st;
        
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
                        st.SertifikaliDosyaNo = dataReader.GetInt32(2);
                        st.MuracaatTarihi = dataReader.GetString(3);
                        st.SertifikaNo = dataReader.GetString(4);
                        st.FaturaNo = dataReader.GetString(5);
                        st.FaturaTarihi = dataReader.GetString(6);
                        st.FirmaAdi = dataReader.IsDBNull(7) ? "" : dataReader.GetString(7);
                        st.Urun = dataReader.IsDBNull(8) ? "" : dataReader.GetString(8);
                        st.UrunCesidi = dataReader.IsDBNull(9) ? "" : dataReader.GetString(9);
                        st.Miktari = dataReader.IsDBNull(10) ? "" : dataReader.GetString(10);
                        st.BirimFiyati = dataReader.IsDBNull(11) ? "" : dataReader.GetString(11);
                        st.ToplamMaliyet = dataReader.IsDBNull(12) ? "" : dataReader.GetString(12);
                        stList.Add(st);

                    }

                }

            });
            return stList;
        }

        public int Update(SertifikaliTohum Entity)
        {
            _try(() =>
            {
                command.CommandText = "update SertifikaliTohum set CksId=@CksId,SertifikaliDosyaNo=@SertifikaliDosyaNo,MuracaatTarihi=@MuracaatTarihi,SertifikaNo=@SertifikaNo,FaturaNo=@FaturaNo,FaturaTarihi=@FaturaTarihi,FirmaAdi=@FirmaAdi,Urun=@Urun,UrunCesidi=@UrunCesidi,Miktari=@Miktari,BirimFiyati=@BirimFiyati,ToplamMaliyet=@ToplamMaliyet where Id=@Id ";
                command.Parameters.AddWithValue("@Id", Entity.Id);
                command.Parameters.AddWithValue("@CksId", Entity.CksId);
                command.Parameters.AddWithValue("@SertifikaliDosyaNo", Entity.SertifikaliDosyaNo);
                command.Parameters.AddWithValue("@MuracaatTarihi", Entity.MuracaatTarihi);
                command.Parameters.AddWithValue("@SertifikaNo", Entity.SertifikaNo);
                command.Parameters.AddWithValue("@FaturaNo", Entity.FaturaNo);
                command.Parameters.AddWithValue("@FaturaTarihi", Entity.FaturaTarihi);
                command.Parameters.AddWithValue("@FirmaAdi", Entity.FirmaAdi);
                command.Parameters.AddWithValue("@Urun", Entity.Urun);
                command.Parameters.AddWithValue("@UrunCesidi", Entity.UrunCesidi);
                command.Parameters.AddWithValue("@Miktari", Entity.Miktari);
                command.Parameters.AddWithValue("@BirimFiyati", Entity.BirimFiyati);
                command.Parameters.AddWithValue("@ToplamMaliyet", Entity.ToplamMaliyet);

                command.Prepare();
                result = command.ExecuteNonQuery();

            });
            return result;
        }



        private void _try(Action action)
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
