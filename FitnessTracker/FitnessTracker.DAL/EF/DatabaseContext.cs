using System.Data.Entity;
using FitnessTracker.DAL.Interfaces;

namespace FitnessTracker.DAL.EF
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        static DatabaseContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public DatabaseContext(string connectionString) : base(connectionString)
        {
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}