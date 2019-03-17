using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    class MemoryRepositroy : IRepository
    {
        private Dictionary<string, Product> products;

        public MemoryRepositroy()
        {
            products = new Dictionary<string, Product>();
            new List<Product>
            {
                new Product{Name="Kajak",Price=15000},
                new Product{Name="LifeJaket",Price=20000},
                new Product{Name="Soccer Ball",Price=8000},
            }.ForEach(p => AddProduct(p));
        }

        public Product this[string name] => products[name];

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product)
        {
            products[product.Name]=product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product.Name);
        }
    }
}
