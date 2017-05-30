﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities.Statistics
{
    [Table("BalanceStatistic")]
    public class BalanceStatistic : BaseType
    {
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public string SessionEvaluation { get; set; }

        public decimal LeftWeightShift { get; set; }

        public decimal RightWeightShift { get; set; }

        public decimal FrontWeightShift { get; set; }

        public decimal BackWeightShift { get; set; }
    }
}