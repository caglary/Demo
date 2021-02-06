using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CksKayitDefteri.Business
{
    public class YemBitkileriManager : BaseService<YemBitkileri>
    {
        
        public YemBitkileriManager()
        {
            _dal = new YemBitkileriDal();
        }

        

        public List<YemBitkileri> GetByCiftci(int cksId)
        {
            return GetAll().Where(I => I.CksId == cksId).ToList();
        }

        internal DataTable GetAllDataTable(int id)
        {
            return _dal.GetAllDataTable(id);
        }
    }
}
