using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Otamimi.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "ID Number")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm ID Number")]
        [Compare("Password", ErrorMessage = "The ID Number and confirmation ID do not match.")]
        public string ConfirmPassword { get; set; }
        public string IDnumber { get; internal set; }
        public string Role { get; set; }
    }
}
