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

        


        internal DataTable GetAllDataTable(int id)
        {
            return _dal.GetAllDataTable(id);
        }
        public DataTable GetAllByQuery(string query)
        {
            return _dal.GetAllByQuery(query);
        }
    }
}
