using System;

namespace FitnessTracker.BLL.DTO
{
    public class WatchStatisticDto
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartExcerciseTime { get; set; }

        public DateTime FinishExcerciseTime { get; set; }

        public decimal AverageHeartbeat { get; set; }

        public float KaloriesBurnt { get; set; }
    }
}