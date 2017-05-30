using System;

namespace FitnessTracker.BLL.DTO
{
    public class FilterDto
    {
        public DateTime FromDateTime { get; set; }

        public DateTime ToDateTime { get; set; }

        public DateTime Date { get; set; }
    }
}