using System.Security.Principal;
using System.Web;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Auth.Interfaces
{
    public interface IAuthentication
    {
        HttpContext HttpContext { set; }

        IPrincipal CurrentUser { get; }

        User Login(string login, string password, bool isPersistent);

        User Login(string login);

        void LogOut();
    }
}