using System.Collections.Generic;
using System.Security.Principal;
using AutoMapper;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.Auth.Interfaces;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Auth.Principal
{
    public class UserIdentity: IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType => typeof(User).ToString();

        public bool IsAuthenticated => User != null;

        public string Name => User != null ? User.Email : "Guest";

        public IEnumerable<string> Roles()
        {
            return User.Roles;
        }

        public void Init(string userName, IUserService repository, IMapper mapper)
        {
            if(!string.IsNullOrEmpty(userName))
            {
                User = mapper.Map<User>(repository.Get(userName));
            }
        }
    }
}