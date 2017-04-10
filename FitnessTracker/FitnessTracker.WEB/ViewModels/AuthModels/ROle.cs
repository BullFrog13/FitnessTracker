using System.Collections.Generic;
using System.Web.Mvc;

namespace FitnessTracker.WEB.ViewModels.AuthModels
{
    public class Role
    {
        [HiddenInput]
        public int RoleId { get; set; }

        [HiddenInput]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}