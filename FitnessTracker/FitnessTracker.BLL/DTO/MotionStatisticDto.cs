using System;

namespace FitnessTracker.BLL.DTO
{
    public class MotionStatisticDto
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public decimal KilometersWalked { get; set; }
    }
}