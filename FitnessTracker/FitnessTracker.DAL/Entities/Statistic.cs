using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities
{
    [Table("Statistic")]
    public class Statistic : BaseType
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}