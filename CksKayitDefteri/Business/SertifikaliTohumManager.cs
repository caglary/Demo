using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CksKayitDefteri.Business
{
    public class SertifikaliTohumManager:IService
    {
        SertifikaliTohumDal _dal;
        public SertifikaliTohumManager()
        {
            _dal = new SertifikaliTohumDal();
        }

        public List<SertifikaliTohum> GetAll()
        {
            return _dal.GetAll();
        }
        public int Add(SertifikaliTohum Entity)
        {
            EntityControl(Entity);
            return _dal.Add(Entity);
        }
        public int Delete(SertifikaliTohum Entity)
        {
            if (Entity.Id == 0)
                throw new Exception("Kayıt seçimi yapınız.");
            return _dal.Delete(Entity);
        }
        public int Update(SertifikaliTohum Entity)
        {
            if (Entity.Id == 0)
                throw new Exception("Kayıt seçimi yapınız.");
            return _dal.Update(Entity);
        }
        public List<SertifikaliTohum> Get(string Tc)
        {
            return _dal.Get(Tc);
        }
        public SertifikaliTohum GetById(int Id)
        {
            return _dal.GetById(Id);
        }

        private static void EntityControl(SertifikaliTohum Entity)
        {
            if (Entity.CksId == 0 || Entity.SertifikaliDosyaNo == 0 || string.IsNullOrEmpty(Entity.FaturaNo) || string.IsNullOrEmpty(Entity.FaturaTarihi) || string.IsNullOrEmpty(Entity.FirmaAdi) || string.IsNullOrEmpty(Entity.SertifikaNo) || string.IsNullOrEmpty(Entity.MuracaatTarihi) || string.IsNullOrEmpty(Entity.Miktari) || string.IsNullOrEmpty(Entity.Urun))
            {
                throw new Exception("Form alanlarını eksiksiz doldurunuz.");
            }
        }
    }
}
