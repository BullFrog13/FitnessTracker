using System.Security.Principal;
using AutoMapper;
using FitnessTracker.BLL.Interfaces;

namespace FitnessTracker.WEB.Auth.Principal
{
    public class UserProvider : IPrincipal
    {
        public UserProvider(IUserService repository, IMapper mapper, string name)
        {
            UserIdentity = new UserIdentity();
            UserIdentity.Init(name, repository, mapper);
        }

        public IIdentity Identity => UserIdentity;

        private UserIdentity UserIdentity { get; }

        public bool IsInRole(string role)
        {
            return UserIdentity.User != null && UserIdentity.User.InRoles(role);
        }

        public override string ToString()
        {
            return UserIdentity.Name;
        }
    }
}