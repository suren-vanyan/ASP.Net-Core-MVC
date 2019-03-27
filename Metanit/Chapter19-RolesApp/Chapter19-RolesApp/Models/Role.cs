using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter19_RolesApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
