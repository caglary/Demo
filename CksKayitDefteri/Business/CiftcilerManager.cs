using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
namespace App.Business
{
    public class CiftcilerManager : BaseService<Ciftci>
    {
        //CiftciDal dal;
        public CiftcilerManager()
        {
            _dal = new CiftciDal();
        }
        public Ciftci GetByTc(string Tc)
        {
            if (!string.IsNullOrEmpty(Tc) && Tc.Length == 11)
            {
                return _dal.GetAll().Where(I=>I.TcKimlikNo==Tc).FirstOrDefault();
            }
            else
            {
                throw new Exception("Tc Numarasını kontrol ediniz.");
            }
        }
        public override int Add(Ciftci ciftci)
        {
            int returnValue = 0;
            if (string.IsNullOrEmpty(ciftci.TcKimlikNo) || string.IsNullOrEmpty(ciftci.NameSurname) || string.IsNullOrEmpty(ciftci.FatherName) || string.IsNullOrEmpty(ciftci.City) || string.IsNullOrEmpty(ciftci.Town) || string.IsNullOrEmpty(ciftci.Village))
            {
                throw new Exception("Formu tekrar kontrol ediniz.Yıldızlı alanları doldurunuz.");
            }
            returnValue= _dal.Add(ciftci);
            return returnValue;
        }
        public override int Delete(Ciftci ciftci)
        {
            int returnValue = 0;
            returnValue = _dal.Delete(ciftci);
            return returnValue;
        }
        public override int Update(Ciftci ciftci)
        {
            int returnValue = 0;
            if (string.IsNullOrEmpty(ciftci.TcKimlikNo) || string.IsNullOrEmpty(ciftci.NameSurname) || string.IsNullOrEmpty(ciftci.FatherName) || string.IsNullOrEmpty(ciftci.City) || string.IsNullOrEmpty(ciftci.Town) || string.IsNullOrEmpty(ciftci.Village))
            {
                throw new Exception("Formu tekrar kontrol ediniz.Yıldızlı alanları doldurunuz.");
            }
            returnValue = _dal.Update(ciftci);
            return returnValue;
        }
    }
}
