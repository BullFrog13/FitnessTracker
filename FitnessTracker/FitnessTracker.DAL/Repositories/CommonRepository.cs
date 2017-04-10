using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.DAL.Repositories
{
    public class CommonRepository<TEntity> : IRepository<TEntity> where TEntity : BaseType
    {
        private readonly DbContext _db;

        public CommonRepository(DbContext db)
        {
            _db = db;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _db.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual void Create(TEntity item)
        {
            _db.Set<TEntity>().Add(item);
        }

        public virtual void Update(TEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var item =  Get(id);
            _db.Set<TEntity>().Remove(item);
        }
    }
}