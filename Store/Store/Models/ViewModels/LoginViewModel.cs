using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class LoginViewModel
    {
    
        [Required]
        [Display(Name = "UserName")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
