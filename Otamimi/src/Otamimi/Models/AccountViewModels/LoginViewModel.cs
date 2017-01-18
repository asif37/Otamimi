using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Otamimi.Models.AccountViewModels
{
    public class LoginViewModel
    {
        
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }
       
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="ID Number")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
