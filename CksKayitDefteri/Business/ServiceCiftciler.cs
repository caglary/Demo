using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace App.Business
{
    public class ServiceCiftciler : IService
    {
        CiftciDal dal;
        public ServiceCiftciler()
        {
            dal = new CiftciDal();
        }
        public List<Ciftci> GetAll()
        {
            return dal.GetAll();
        }
        public Ciftci GetByTc(string Tc)
        {
            if (!string.IsNullOrEmpty(Tc) && Tc.Length == 11)
            {
                return dal.Get(Tc);
            }
            else
            {
                throw new Exception("Tc Numarasını kontrol ediniz.");
            }
        }

        public int Add(Ciftci ciftci)
        {
            int returnValue = 0;
            if (string.IsNullOrEmpty(ciftci.TcKimlikNo) || string.IsNullOrEmpty(ciftci.NameSurname) || string.IsNullOrEmpty(ciftci.FatherName) || string.IsNullOrEmpty(ciftci.City) || string.IsNullOrEmpty(ciftci.Town) || string.IsNullOrEmpty(ciftci.Village))
            {
                throw new Exception("Formu tekrar kontrol ediniz.Yıldızlı alanları doldurunuz.");
            }
            returnValue= dal.Add(ciftci);
            return returnValue;
        }

        internal int Delete(Ciftci ciftci)
        {
            int returnValue = 0;
            returnValue = dal.Delete(ciftci);
            return returnValue;
        }

        internal int Update(Ciftci ciftci)
        {
            int returnValue = 0;
            if (string.IsNullOrEmpty(ciftci.TcKimlikNo) || string.IsNullOrEmpty(ciftci.NameSurname) || string.IsNullOrEmpty(ciftci.FatherName) || string.IsNullOrEmpty(ciftci.City) || string.IsNullOrEmpty(ciftci.Town) || string.IsNullOrEmpty(ciftci.Village))
            {
                throw new Exception("Formu tekrar kontrol ediniz.Yıldızlı alanları doldurunuz.");
            }
            returnValue = dal.Update(ciftci);
            return returnValue;
        }
    }
}
