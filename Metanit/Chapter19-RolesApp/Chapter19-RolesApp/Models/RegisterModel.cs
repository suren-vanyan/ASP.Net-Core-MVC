using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter19_RolesApp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Email is Empty")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Passwrod is Empty")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }
    }
}
