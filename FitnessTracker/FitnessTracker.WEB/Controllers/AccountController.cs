using System.Web.Mvc;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.Auth.Interfaces;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAuthentication _authentication;

        public AccountController(IAuthentication authentication, IMapper mapper, IUserService userService)
        {
            _authentication = authentication;
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet]
        [Route(Name = "Login1")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route(Name = "Login2")]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if(!ModelState.IsValid)
            {
                return View(loginModel);
            }

            var user = _authentication.Login(loginModel.Email, loginModel.Password, loginModel.RememberMe);

            if(user != null)
            {
                return RedirectToAction("GetGames", "Game");
            }

            return View(loginModel);
        }

        [Authorize]
        [HttpGet]
        [Route(Name = "Logout")]
        public ActionResult Logout()
        {
           _authentication.LogOut();

            return RedirectToAction("GetGames", "Game", null);
        }

        [HttpGet]
        [Route(Name = "Register1")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route(Name = "Register2")]
        public ActionResult Register(NewUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userDto = _mapper.Map<UserDto>(model);
            _userService.Create(userDto);

            return RedirectToAction("GetGames", "Game", null);
        }
    }
}