using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class ProductTotalizer
    {
        public ProductTotalizer(IRepository repo)
        {
            Repository = repo;
        }
        public IRepository Repository { get; set; }
        public decimal Total => Repository.Products.Sum(p => p.Price);

    }
}
