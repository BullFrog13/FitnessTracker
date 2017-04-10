using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities
{
    [Table("Profile")]
    public class Profile : BaseType
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}