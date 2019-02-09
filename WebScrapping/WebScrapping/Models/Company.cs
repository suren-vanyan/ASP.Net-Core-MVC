using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScrapping.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Type { get; set; }
        public int NumberOfEmployees { get; set; }
        public string AboutCompany { get; set; }
        public string WebSite { get; set; }
        public string Adress { get; set; }    
        public int DateOfFoundation { get; set; }
        public int JobsHistory { get; set; }
    }
}
