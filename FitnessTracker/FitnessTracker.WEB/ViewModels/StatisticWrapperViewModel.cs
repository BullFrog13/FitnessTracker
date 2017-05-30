using System.Collections.Generic;

namespace FitnessTracker.WEB.ViewModels
{
    public class StatisticWrapperViewModel
    {
        public IList<BalanceStatisticViewModel> BalanceStatistics { get; set; }

        public IList<MotionStatisticViewModel> MotionStatistics { get; set; }

        public IList<WatchStatisticViewModel> WatchStatistics { get; set; }
    }
}