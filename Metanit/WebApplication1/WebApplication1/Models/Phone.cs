using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; } // название смартфона
        public string Company { get; set; } // компания
        public int Price { get; set; } // цена
    }
}
