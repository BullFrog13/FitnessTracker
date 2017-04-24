using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FitnessTracker.DAL.EF;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Interfaces;
using FitnessTracker.DAL.Repositories;

namespace FitnessTracker.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _databaseContext;
        private bool _disposed;
        //private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        private IRepository<User> _userRepository;

        public UnitOfWork(string databaseConnectionString)
        {
            _databaseContext = new DatabaseContext(databaseConnectionString);
        }


        public IRepository<User> Users => _userRepository ?? (_userRepository = new CommonRepository<User>(_databaseContext));

        /* public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseType
         {
             if (_repositories.Keys.Contains(typeof(TEntity)))
             {
                 return _repositories[typeof(TEntity)] as IRepository<TEntity>;
             }
 
             var repository = new CommonRepository<TEntity>(_databaseContext);
             _repositories.Add(typeof(TEntity), repository);
 
             return repository;
         }*/

        public void Save()
        {
            _databaseContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _databaseContext.Dispose();
            }

            _disposed = true;
        }
    }
}