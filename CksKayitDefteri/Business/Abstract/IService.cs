using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace App.Business.Abstract
{
    public interface IService<T>
    {
        int Add(T Entity);
        int Update(T Entity);
        int Delete(T Entity);
        List<T> GetAll();
    }
}
