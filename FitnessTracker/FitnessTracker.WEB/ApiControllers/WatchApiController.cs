using System.Net;
using System.Web.Http;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.ApiControllers
{
    [RoutePrefix("api/watch")]
    public class WatchApiController : ApiController
    {
        private readonly IWatchStatisticService _watchStatisticService;
        private readonly IMapper _mapper;

        public WatchApiController(IWatchStatisticService watchStatisticService, IMapper mapper)
        {
            _watchStatisticService = watchStatisticService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] WatchStatisticViewModel model)
        {
            if(ModelState.IsValid)
            {
                var motionStatisticDto = _mapper.Map<WatchStatisticDto>(model);
                _watchStatisticService.Create(motionStatisticDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }
    }
}
