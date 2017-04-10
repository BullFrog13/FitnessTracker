using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.DAL.Entities
{
    public class BaseType
    {
        [Key]
        public int Id { get; set; }
    }
}