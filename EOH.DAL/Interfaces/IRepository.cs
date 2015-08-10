using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOH.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T SelectByID(int id);
        IEnumerable<T> SelectAll();
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        void Save();

    }
}
