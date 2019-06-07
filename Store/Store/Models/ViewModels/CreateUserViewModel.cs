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

        public string Email { get; set; }

        public string Password  { get; set; }

        public int Year { get; set; }
    }
}
