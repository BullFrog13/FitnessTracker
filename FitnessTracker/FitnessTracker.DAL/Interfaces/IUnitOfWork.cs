using System;
using System.Threading.Tasks;
using FitnessTracker.DAL.Entities;

namespace FitnessTracker.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : BaseType;

        void Save();

        Task SaveAsync();
    }
}