using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities.Statistics
{
    [Table("WatchStatistic")]
    public class WatchStatistic : BaseType
    {
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartExcerciseTime { get; set; }

        public DateTime FinishExcerciseTime { get; set; }

        public decimal AverageHeartbeat { get; set; }

        public float KaloriesBurnt { get; set; }
    }
}