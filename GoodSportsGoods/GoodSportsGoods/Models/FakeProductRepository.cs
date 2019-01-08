using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodSportsGoods.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name="Football",Price=25},
            new Product{Name="Basketball Shoe",Price=50},
            new Product{Name="Soccer Jerseys",Price=27},
            new Product{Name="Sweatshirt",Price=39},
            new Product{Name="Active Sweatpants",Price=25.70M},
            new Product { Name = "Surf board", Price = 179 },
        }.AsQueryable<Product>();
        
    }
}
