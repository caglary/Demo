using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace App.Business
{
    public class CksManager : IService
    {
        CksDal dal;
        public CksManager()
        {
            dal = new CksDal();
        }
        public List<Cks> GetAll()
        {
            return dal.GetAll();
        }
        public Cks GetByTc(string tc)
        {
            return dal.Get(tc);
        }
        public int Add(Cks entity)
        {
            return dal.Add(entity);
        }
        public int Delete(Cks entity)
        {
            return dal.Delete(entity);
        }

        internal int DosyaNoFactory()
        {
            var liste = GetAll();
                      
            return liste.Count + 1;
        }

        internal int Update(Cks ciftci)
        {
           return dal.Update(ciftci);
        }

        internal List<Cks> Search(string text)
        {
            var liste = GetAll();
            List<Cks> filteredList = new List<Cks>();
            List<int> idList = new List<int>();
            //isimsoyisim içerisinde arama
            IEnumerable<Cks> searchIsimSoyisim = liste.Where(I => I.IsimSoyisim.ToLower().Contains(text.ToLower()));
            if (searchIsimSoyisim!=null)
            {
                foreach (var item in searchIsimSoyisim)
                {
                    idList.Add(item.Id);
                }
            }
            
            //Tc no içerisinde arama
            IEnumerable<Cks> searchTc = liste.Where(I => I.Tc.ToLower().Contains(text.ToLower()));
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
