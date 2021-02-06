using System.Collections.Generic;
using System.Data;

namespace Database.Abstract
{
    public interface IDatabase<T>
    {
        int Add(T Entity);
        int Delete(T Entity);
        int Update(T Entity);
        List<T> GetAll();
        DataTable GetAllDataTable(int id);
    }
}