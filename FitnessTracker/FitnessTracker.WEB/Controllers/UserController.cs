using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var usersDto = _userService.GetAll();
            var usersViewModel = Mapper.Map<IEnumerable<UserViewModel>>(usersDto);

            return View(usersViewModel);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var userDto = _userService.Get(id);
            var userViewModel = Mapper.Map<UserViewModel>(userDto);

            return View(userViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var userDto = Mapper.Map<UserDto>(userViewModel);
            _userService.Create(userDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var userDto = _userService.Get(id);
            var userViewModel = Mapper.Map<UserViewModel>(userDto);

            return View(userViewModel);
        }

        [HttpPost]
        public ActionResult Edit(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var userDto = Mapper.Map<UserDto>(userViewModel);
            _userService.Edit(userDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            _userService.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}