using System.Net;
using System.Web.Http;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.ApiControllers
{
    [RoutePrefix("api/balance")]
    public class BalanceApiController : ApiController
    {
        private readonly IBalanceStatisticService _balanceStatisticService;
        private readonly IMapper _mapper;

        public BalanceApiController(IBalanceStatisticService balanceStatisticService, IMapper mapper)
        {
            _balanceStatisticService = balanceStatisticService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create([FromBody] BalanceStatisticViewModel model)
        {
            if(ModelState.IsValid)
            {
                var balanceStatisticDto = _mapper.Map<BalanceStatisticDto>(model);
                _balanceStatisticService.Create(balanceStatisticDto);

                return StatusCode(HttpStatusCode.Created);
            }

            return BadRequest(ModelState);
        }
    }
}