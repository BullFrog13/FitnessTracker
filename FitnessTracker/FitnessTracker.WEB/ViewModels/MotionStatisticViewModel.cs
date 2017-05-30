using System;

namespace FitnessTracker.WEB.ViewModels
{
    public class MotionStatisticViewModel
    {
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public decimal KilometersWalked { get; set; }
    }
}