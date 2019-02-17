using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        [BindingBehavior(BindingBehavior.Required)]
        public string Name { get; set; }
        [BindingBehavior(BindingBehavior.Optional)]
        public int Age { get; set; }
        [BindingBehavior(BindingBehavior.Never)]
        public bool HasRight { get; set; }
    }
}
