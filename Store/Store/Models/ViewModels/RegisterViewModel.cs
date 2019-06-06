using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name="Year of birth")]
        [Range(0,110)]
        public int Year { get; set; }

        [Required]
        [Display(Name= "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name= "ConfirmPassword")]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password),]
        public string ConfirmPassword { get; set; }

        public string  ReturnUrl { get; set; }
    }
}
