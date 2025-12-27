using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PRUEBA_TECNICA_IMOVS.Models;

namespace PRUEBA_TECNICA_IMOVS.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly Context _context;
        private readonly DbSet<T> _entitySet;

        public Repository(Context context)
        {
            _context = context;
            _entitySet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entitySet.ToList();
        }

        public T GetById(object id)
        {
            return _entitySet.Find(id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entitySet.Where(predicate).ToList();
        }

        public void Add(T entity)
        {
            _entitySet.Add(entity);
        }

        public void Update(T entity)
        {
            _entitySet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T entity = _entitySet.Find(id);
            if (entity != null)
            {
                _entitySet.Remove(entity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
