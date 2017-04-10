using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using FitnessTracker.BLL.DTO;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.ViewModels;

namespace FitnessTracker.WEB.Controllers
{
    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var statisticsDto = _statisticService.GetAll();
            var statisticsViewModel = Mapper.Map<IEnumerable<StatisticViewModel>>(statisticsDto);

            return View(statisticsViewModel);
        }

        [HttpGet]
        public ActionResult Get(int id)
        {
            var statisticDto = _statisticService.Get(id);
            var statisticViewModel = Mapper.Map<StatisticViewModel>(statisticDto);

            return View(statisticViewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StatisticViewModel statisticViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(statisticViewModel);
            }

            var statisticDto = Mapper.Map<StatisticDto>(statisticViewModel);
            _statisticService.Create(statisticDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var statisticDto = _statisticService.Get(id);
            var statisticViewModel = Mapper.Map<StatisticViewModel>(statisticDto);

            return View(statisticViewModel);
        }

        [HttpPost]
        public ActionResult Edit(StatisticViewModel statisticViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(statisticViewModel);
            }

            var statisticDto = Mapper.Map<StatisticDto>(statisticViewModel);
            _statisticService.Edit(statisticDto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Delete(int id)
        {
            _statisticService.Delete(id);

            return RedirectToAction("Index", "Home");
        }
    }
}