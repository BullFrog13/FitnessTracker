using System.Collections.Generic;
using FitnessTracker.DAL.Entities.Statistics;
namespace FitnessTracker.DAL.Entities
{
    public class User : BaseType
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<BalanceStatistic> BalanceStatistic { get; set; }

        public virtual ICollection<MotionStatistic> MotionStatstic { get; set; }

        public virtual ICollection<WatchStatistic> WatchStatistic { get; set; }
    }
}