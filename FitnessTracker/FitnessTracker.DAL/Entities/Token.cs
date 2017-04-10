using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTracker.DAL.Entities
{
    public class Token : BaseType
    {
        [ForeignKey("User")]
        public int UserId { get; set; }

        public string AuthToken { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}