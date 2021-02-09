using App.Business.Abstract;
using Database.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Business.Abstract
{
    public class BaseService<T> : IService<T>
    {
        public IDatabase<T> _dal;
        public virtual int Add(T Entity)
        {
            return _dal.Add(Entity);
        }
        public virtual int Delete(T Entity)
        {
            return _dal.Delete(Entity);
        }
        public virtual List<T> GetAll()
        {
            return _dal.GetAll();
        }
        public virtual int Update(T Entity)
        {
            return _dal.Update(Entity);
        }
    }
}
