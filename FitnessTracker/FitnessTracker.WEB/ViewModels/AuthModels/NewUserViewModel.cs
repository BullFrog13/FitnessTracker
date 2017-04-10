using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FitnessTracker.WEB.ViewModels.AuthModels
{
    public class NewUserViewModel
    {
        [HiddenInput]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [StringLength(255, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DataType(DataType.Password)]
        [Required]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }

        public List<string> SelectedRoles { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}