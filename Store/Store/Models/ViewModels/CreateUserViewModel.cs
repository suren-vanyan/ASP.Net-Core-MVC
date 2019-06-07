using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password  { get; set; }
        [Required]
        public int Year { get; set; }
    }
}
