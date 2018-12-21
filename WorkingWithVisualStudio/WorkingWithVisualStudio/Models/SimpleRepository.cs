using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkingWithVisualStudio.Models
{
    public class SimpleRepository
    {
        private Dictionary<string, Product> products= new Dictionary<string, Product>();

        public static SimpleRepository SharedRepository { get; } = new SimpleRepository();
        public SimpleRepository()
        {
            var initialItems = new[]
            {
            new Product { Name = "գնդակ", Price = 10M },
            new Product { Name = "վերնաշապիկ", Price = 15M },
            new Product { Name = "սպորտային կոշիկներ", Price = 19.50M },
            new Product { Name = "ներքնազգեստ", Price = 50M }
           };
            foreach (var p in initialItems)
            {
                AddProduct(p);
            }
            products.Add("Eror", null);
        }
        public IEnumerable<Product> Products => products.Values;
        public void AddProduct(Product p) => products.Add(p.Name, p);
    }
}
