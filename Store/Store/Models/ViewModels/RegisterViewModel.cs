﻿using System;
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
        [EmailAddress( ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [Display(Name="Year of birth")]
        [Range(1,110,ErrorMessage ="Year must be les then 110")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        [Required]
        [Display(Name= "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name= "ConfirmPassword")]
        [Compare("Password",ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password),]
        public string ConfirmPassword { get; set; }

       
    }
}
