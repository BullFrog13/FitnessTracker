using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.ApiControllers
{
    [RoutePrefix("api/profiles")]
    public class ApiProfileController : ApiController
    {
        private readonly IProfileService _profileService;

        public ApiProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var profilesDto = _profileService.GetAll();
            var profilesViewModel = Mapper.Map<IEnumerable<ProfileViewModel>>(profilesDto).ToList();

            return Ok(profilesViewModel);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
                var profileDto = _profileService.Get(id);
                var profileViewModel = Mapper.Map<ProfileViewModel>(profileDto);

                return Ok(profileViewModel);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                var profileDto = Mapper.Map<ProfileDto>(profileViewModel);
                _profileService.Create(profileDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut, Route("")]
        public IHttpActionResult Edit(ProfileViewModel profileViewModel)
        {
            if (ModelState.IsValid)
            {
                var profileDto = Mapper.Map<ProfileDto>(profileViewModel);
                _profileService.Edit(profileDto);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _profileService.Delete(id);

            return Ok();
        }
    }
}