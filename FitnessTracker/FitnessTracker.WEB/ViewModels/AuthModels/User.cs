using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.WEB.ViewModels.AuthModels
{
    public class User
    {
        public User()
        {
            Roles = new List<string>();
        }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public bool InRoles(string roles)
        {
            if (string.IsNullOrWhiteSpace(roles))
            {
                return false;
            }

            var rolesArray = roles.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return rolesArray.Select(role => Roles.Contains(role)).Any(hasRole => hasRole);
        }
    }
}