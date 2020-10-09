using CrudMed.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMed.Services
{
    public class GeneryRepository<T> : IRepository<T> where T : class
    {
        private readonly CrudMedicoContext _Context;
        private DbSet<T> _Table;

        public GeneryRepository(CrudMedicoContext Context)
        {
            _Context = Context;
            _Table = _Context.Set<T>();
        }
        public void Delete(int id)
        {
            T exits = _Table.Find(id);
            _Context.Remove(exits);
            
        }

        public List<T> GetAll()
        {
            return _Table.ToList();
        }

        public T GetId(int Id)
        {
            return _Table.Find(Id);
        }

        public void Insert(T entity)
        {
            _Table.Add(entity);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void Update(T entity)
        {
          //  _Table.Add(entity);
            _Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
