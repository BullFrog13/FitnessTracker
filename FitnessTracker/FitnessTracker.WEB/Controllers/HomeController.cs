using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWatchStatisticService _watchStatisticService;
        private readonly IMotionStatisticService _motionStatisticService;
        private readonly IBalanceStatisticService _balanceStatisticService;
        private readonly IMapper _mapper;

        public HomeController(
            IWatchStatisticService watchStatisticService,
            IMotionStatisticService motionStatisticService,
            IBalanceStatisticService balanceStatisticService,
            IMapper mapper)
        {
            _watchStatisticService = watchStatisticService;
            _motionStatisticService = motionStatisticService;
            _balanceStatisticService = balanceStatisticService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var watchStatDtos = _watchStatisticService.GetAllUserStatistics(User.Identity.Name);
                var balanceStatDtos = _balanceStatisticService.GetAllUserStatistics(User.Identity.Name);
                var motionStatDto = _motionStatisticService.GetAllUserStatistics(User.Identity.Name);

                var watchStatViewModels = _mapper.Map<IList<WatchStatisticViewModel>>(watchStatDtos);
                var balanceStatViewModels = _mapper.Map<IList<BalanceStatisticViewModel>>(balanceStatDtos);
                var motionStatViewModels = _mapper.Map<IList<MotionStatisticViewModel>>(motionStatDto);

                var model = new StatisticWrapperViewModel
                {
                    WatchStatistics = watchStatViewModels,
                    BalanceStatistics = balanceStatViewModels,
                    MotionStatistics = motionStatViewModels
                };

                return View(model);
            }
            return View();
        }
    }
}