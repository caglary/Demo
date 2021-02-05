using App.Business;
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
    public class SertifikaliTohumManager : BaseService<SertifikaliTohum>
    {

        public SertifikaliTohumManager()
        {
            _dal = new SertifikaliTohumDal();
        }


        public override int Add(SertifikaliTohum Entity)
        {
            //EntityControl(Entity);
            return _dal.Add(Entity);
        }
        public override int Delete(SertifikaliTohum Entity)
        {
            if (Entity.Id == 0)
                throw new Exception("Kayıt seçimi yapınız.");
            return _dal.Delete(Entity);
        }
        public override int Update(SertifikaliTohum Entity)
        {
            if (Entity.Id == 0)
                throw new Exception("Kayıt seçimi yapınız.");
            return _dal.Update(Entity);
        }
        public List<SertifikaliTohum> Get(string Tc)
        {
            CksManager cksManager = new CksManager();
            var ciftciKayit = cksManager.GetByTc(Tc);
            return _dal.GetAll().Where(I => I.CksId == ciftciKayit.Id).ToList();
        }
        public SertifikaliTohum GetById(int Id)
        {
            return _dal.GetAll().Where(I => I.Id == Id).FirstOrDefault();
        }

        //private static void EntityControl(SertifikaliTohum Entity)
        //{
        //    if (Entity.CksId == 0 || Entity.SertifikaliDosyaNo == 0 || string.IsNullOrEmpty(Entity.FaturaNo) || string.IsNullOrEmpty(Entity.FaturaTarihi) || string.IsNullOrEmpty(Entity.FirmaAdi) || string.IsNullOrEmpty(Entity.SertifikaNo) || string.IsNullOrEmpty(Entity.MuracaatTarihi) || string.IsNullOrEmpty(Entity.Miktari) || string.IsNullOrEmpty(Entity.Urun))
        //    {
        //        throw new Exception("Form alanlarını eksiksiz doldurunuz.");
        //    }
        //}
    }
}
