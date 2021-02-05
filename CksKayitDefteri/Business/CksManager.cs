using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace App.Business
{
    public class CksManager : BaseService<Cks>
    {
       
        public CksManager()
        {
            _dal = new CksDal();
        }
     
        public Cks GetByTc(string tc)
        {
            return _dal.GetAll().Where(I => I.Tc == tc).FirstOrDefault(); ;
        }
      
       

        public int DosyaNoFactory()
        {
            var liste = GetAll();
                      
            return liste.Count + 1;
        }

      

        public List<Cks> Search(string text)
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
