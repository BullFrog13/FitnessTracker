using System.Web.Mvc;
using FitnessTracker.WEB.Auth.Interfaces;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAuthentication _auth;
        protected User CurrentUser => ((IUserProvider) _auth.CurrentUser.Identity).User;

        public BaseController(IAuthentication authentication)
        {
            _auth = authentication;
        }

    }
}