using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace App.Business
{
    public class ServiceCks2020 : IService
    {
        Cks2020Dal dal;
        public ServiceCks2020()
        {
            dal = new Cks2020Dal();
        }
        public List<Cks2020> GetAll()
        {
            return dal.GetAll();
        }
        public Cks2020 GetByTc(string tc)
        {
            return dal.Get(tc);
        }
        public int Add(Cks2020 entity)
        {
            return dal.Add(entity);
        }
        public int Delete(Cks2020 entity)
        {
            return dal.Delete(entity);
        }

        internal int DosyaNoFactory()
        {
            var liste = GetAll();
                      
            return liste.Count + 1;
        }

        internal int Update(Cks2020 ciftci)
        {
           return dal.Update(ciftci);
        }

        internal List<Cks2020> Search(string text)
        {
            var liste = GetAll();
            List<Cks2020> filteredList = new List<Cks2020>();
            List<int> idList = new List<int>();
            //isimsoyisim içerisinde arama
            IEnumerable<Cks2020> searchIsimSoyisim = liste.Where(I => I.IsimSoyisim.ToLower().Contains(text.ToLower()));
            if (searchIsimSoyisim!=null)
            {
                foreach (var item in searchIsimSoyisim)
                {
                    idList.Add(item.Id);
                }
            }
            
            //Tc no içerisinde arama
            IEnumerable<Cks2020> searchTc = liste.Where(I => I.Tc.ToLower().Contains(text.ToLower()));
            if (searchTc != null)
            {
                foreach (var item in searchTc)
                {
                    idList.Add(item.Id);
                }
            }

            foreach (var id in idList)
            {
                var ciftci = liste.Where(I => I.Id == id).FirstOrDefault();
                filteredList.Add(ciftci);
            }
            return filteredList;



        }
    }
}
