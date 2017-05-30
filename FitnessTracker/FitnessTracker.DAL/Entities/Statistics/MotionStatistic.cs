using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities.Statistics
{
    [Table("MotionStatistic")]
    public class MotionStatistic : BaseType
    {
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public decimal KilometersWalked { get; set; }
    }
}