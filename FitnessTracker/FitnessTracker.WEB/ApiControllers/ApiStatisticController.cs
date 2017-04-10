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
    [RoutePrefix("api/statistics")]
    public class ApiStatisticController : ApiController
    {
        private readonly IStatisticService _statisticService;

        public ApiStatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll()
        {
            var statisticsDto = _statisticService.GetAll();
            var statisticsViewModel = Mapper.Map<IEnumerable<StatisticViewModel>>(statisticsDto).ToList();

            return Ok(statisticsViewModel);
        }

        [HttpGet, Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
                var statisticDto = _statisticService.Get(id);
                var statisticViewModel = Mapper.Map<StatisticViewModel>(statisticDto);

                return Ok(statisticViewModel);
        }

        [HttpPost, Route("")]
        public IHttpActionResult Create(StatisticViewModel statisticViewModel)
        {
            if (ModelState.IsValid)
            {
                var statisticDto = Mapper.Map<StatisticDto>(statisticViewModel);
                _statisticService.Create(statisticDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut, Route("")]
        public IHttpActionResult Edit(StatisticViewModel statisticViewModel)
        {
            if (ModelState.IsValid)
            {
                var statisticDto = Mapper.Map<StatisticDto>(statisticViewModel);
                _statisticService.Edit(statisticDto);

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            _statisticService.Delete(id);

            return Ok();
        }
    }
}