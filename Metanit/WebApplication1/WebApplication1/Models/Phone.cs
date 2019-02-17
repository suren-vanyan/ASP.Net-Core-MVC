using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Manufacturer { get; set; }
        public decimal Price { get; set; }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
