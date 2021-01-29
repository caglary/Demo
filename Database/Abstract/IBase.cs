using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Abstract
{
    public interface IBase<T>
    {
        int Add(T Entity);
        int Delete(T Entity);
        int Update(T Entity);
        List<T> GetAll();
      

    }
}
