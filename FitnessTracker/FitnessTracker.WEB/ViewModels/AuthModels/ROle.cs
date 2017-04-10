using System.Collections.Generic;
using System.Web.Mvc;
using FitnessTracker.BLL.DTO;

namespace FitnessTracker.WEB.ViewModels.AuthModels
{
    public class Role
    {
        [HiddenInput]
        public int RoleId { get; set; }

        [HiddenInput]
        public string RoleName { get; set; }

        public string Description { get; set; }

        public ICollection<UserDto> Users { get; set; }
    }
}