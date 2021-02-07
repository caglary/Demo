using App.Business.Abstract;
using Database.Concrete.Sqlite;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business
{
    public class HububatFarkOdemesiManager : BaseService<HububatFarkOdemesi>
    {
        
        public HububatFarkOdemesiManager()
        {
            _dal = new HububatFarkOdemesiDal();
        }
        public DataTable GetDataTable(int cksid)
        {
           return _dal.GetAllDataTable(cksid);
        }

        internal DataTable GetAllByQuery(string query)
        {
            return _dal.GetAllByQuery(query);
        }
    }
}
