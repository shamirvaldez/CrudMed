using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMed.Services
{
   public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        T GetId(int Id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(int id);

        void Save();

    }
}
