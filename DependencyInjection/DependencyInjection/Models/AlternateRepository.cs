using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class AlternateRepository : IRepository
    {
        private Dictionary<string, Product> _products;
        public AlternateRepository()
        {
            _products = new Dictionary<string, Product>();
            new List<Product>
          {
                new Product { Name = "CornerFlags ", Price = 34.95M},
               new Product { Name = "Stadium", Price = 79500M}
          }.ForEach(р => AddProduct(р));
        }
        public Product this[string name] => _products[name];

        public IEnumerable<Product> Products => _products.Values;

        public void AddProduct(Product product)
        {
            _products[product.Name] = product;
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product.Name);
        }
    }
}
