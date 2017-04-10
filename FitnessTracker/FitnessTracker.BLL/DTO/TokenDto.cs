using System;

namespace FitnessTracker.BLL.DTO
{
    public class TokenDto
    {
        public int UserId { get; set; }

        public string AuthToken { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }
    }
}