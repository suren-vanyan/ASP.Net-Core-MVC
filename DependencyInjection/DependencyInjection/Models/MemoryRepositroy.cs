using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    class MemoryRepositroy : IRepository
    {
        private IМodelStorage storage;
        private string guid = Guid.NewGuid().ToString();

        public MemoryRepositroy(IМodelStorage storage)
        {
            this.storage = storage;
           
            new List<Product>
            {
                new Product{Name="Kajak",Price=15000},
                new Product{Name="LifeJaket",Price=20000},
                new Product{Name="Soccer Ball",Price=8000},
            }.ForEach(p => AddProduct(p));
        }
       
   
        public Product this[string name] => storage[name];

        public IEnumerable<Product> Products => storage.Items;

        public void AddProduct(Product product)
        {
            storage[product.Name]=product;
        }

        public void DeleteProduct(Product product)
        {
            storage.RemoveItem(product.Name);
        }

        public override string ToString()
        {
            return guid;
        }
    }
}
