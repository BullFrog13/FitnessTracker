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
    [RoutePrefix("api/users")]
    public class ApiUserController : ApiController
    {
        private readonly IUserService _userService;

        public ApiUserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var usersDto = _userService.GetAll();
            var usersViewModel = Mapper.Map<IEnumerable<UserViewModel>>(usersDto).ToList();

            return Ok(usersViewModel);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
                var userDto = _userService.Get(id);
                var userViewModel = Mapper.Map<UserViewModel>(userDto);

                return Ok(userViewModel);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = Mapper.Map<UserDto>(userViewModel);
                _userService.Create(userDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut, Route("")]
        public IHttpActionResult Edit(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userDto = Mapper.Map<UserDto>(userViewModel);
                _userService.Edit(userDto);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _userService.Delete(id);

            return Ok();
        }
    }
}