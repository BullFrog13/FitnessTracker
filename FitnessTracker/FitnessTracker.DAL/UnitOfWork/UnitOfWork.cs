using System;
using System.Data.Entity;
using System.Threading.Tasks;
using FitnessTracker.DAL.EF;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Entities.Statistics;
using FitnessTracker.DAL.Interfaces;
using FitnessTracker.DAL.Repositories;

namespace FitnessTracker.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _databaseContext;
        private bool _disposed;

        private IRepository<User> _userRepository;
        private IRepository<WatchStatistic> _watchStatisticRepository;
        private IRepository<BalanceStatistic> _balanceStatisticRepository;
        private IRepository<MotionStatistic> _motionStatisticRepository;

        public UnitOfWork(string databaseConnectionString)
        {
            _databaseContext = new DatabaseContext(databaseConnectionString);
        }


        public IRepository<User> Users => _userRepository ?? (_userRepository = new CommonRepository<User>(_databaseContext));

        public IRepository<WatchStatistic> WatchStatistics => _watchStatisticRepository ?? (_watchStatisticRepository =
                                                                  new CommonRepository<WatchStatistic>(
                                                                      _databaseContext));

        public IRepository<BalanceStatistic> BalanceStatistics => _balanceStatisticRepository ?? (_balanceStatisticRepository =
                                                                  new CommonRepository<BalanceStatistic>(
                                                                      _databaseContext));


        public IRepository<MotionStatistic> MotionStatistics => _motionStatisticRepository ?? (_motionStatisticRepository =
                                                                  new CommonRepository<MotionStatistic>(
                                                                      _databaseContext));

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