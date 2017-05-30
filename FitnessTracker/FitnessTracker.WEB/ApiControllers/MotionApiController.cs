using System.Net;
using System.Web.Http;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.ApiControllers
{
    [RoutePrefix("api/motion")]
    public class MotionApiController : ApiController
    {
        private readonly IMotionStatisticService _motionStatisticService;
        private readonly IMapper _mapper;

        public MotionApiController(IMotionStatisticService motionStatisticService, IMapper mapper)
        {
            _motionStatisticService = motionStatisticService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] MotionStatisticViewModel model)
        {
            if (ModelState.IsValid)
            {
                var motionStatisticDto = _mapper.Map<MotionStatisticDto>(model);
                _motionStatisticService.Create(motionStatisticDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }
    }
}