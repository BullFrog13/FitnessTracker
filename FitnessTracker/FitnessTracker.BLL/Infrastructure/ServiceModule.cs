using FitnessTracker.DAL.EF;
using Ninject.Modules;
using FitnessTracker.DAL.Interfaces;
using FitnessTracker.DAL.UnitOfWork;

namespace FitnessTracker.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(_connectionString);
            Bind<IDatabaseContext>().To<DatabaseContext>();
        }
    }
}