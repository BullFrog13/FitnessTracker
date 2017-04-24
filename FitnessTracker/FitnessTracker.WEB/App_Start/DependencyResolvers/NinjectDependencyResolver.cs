using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Ninject;
using NLog;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.BLL.Services;
using FitnessTracker.WEB.Auth.Interfaces;
using FitnessTracker.WEB.Auth.Principal;
using FitnessTracker.WEB.AutomapperRegistrations;
using Ninject.Web.Common;

namespace FitnessTracker.WEB.DependencyResolvers
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            _kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            _kernel.Bind<IUserService>().To<UserService>();

            _kernel.Bind<ITokenService>().To<TokenService>();

            _kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();

            _kernel.Bind<ILogger>().ToMethod(p =>
            {
                if (p.Request.Target != null && p.Request.Target.Member.DeclaringType != null)
                {
                    return LogManager.GetLogger(p.Request.Target.Member.DeclaringType.ToString());
                }

                return LogManager.GetLogger("Filter logging");
            });

            var autoMapperConfiguration = new AutoMapperConfiguration();
            _kernel.Bind<IMapper>().ToConstant(autoMapperConfiguration.Configure().CreateMapper()).InSingletonScope();
        }
    }
}