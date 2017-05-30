using System;
using System.Threading.Tasks;
using FitnessTracker.DAL.Entities;
using FitnessTracker.DAL.Entities.Statistics;

namespace FitnessTracker.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }

        IRepository<WatchStatistic> WatchStatistics { get; }

        IRepository<MotionStatistic> MotionStatistics { get; }

        IRepository<BalanceStatistic> BalanceStatistics { get; }

        void Save();

        Task SaveAsync();
    }
}