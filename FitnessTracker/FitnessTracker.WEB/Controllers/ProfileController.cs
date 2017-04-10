using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var profilesDto = _profileService.GetAll();
            var profilesViewModel = Mapper.Map<IEnumerable<ProfileViewModel>>(profilesDto);

            return View(profilesViewModel);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var profileDto = _profileService.Get(id);
            var profileViewModel = Mapper.Map<ProfileViewModel>(profileDto);

            return View(profileViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(profileViewModel);
            }

            var profileDto = Mapper.Map<ProfileDto>(profileViewModel);
            _profileService.Create(profileDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var profileDto = _profileService.Get(id);
            var profileViewModel = Mapper.Map<ProfileViewModel>(profileDto);

            return View(profileViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProfileViewModel profileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(profileViewModel);
            }

            var profileDto = Mapper.Map<ProfileDto>(profileViewModel);
            _profileService.Edit(profileDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            _profileService.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}