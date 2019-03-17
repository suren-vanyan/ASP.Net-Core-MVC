using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public class DictionaryStorage : IМodelStorage
    {
        private Dictionary<string, Product> items= new Dictionary<string, Product>();
        public Product this[string key]
        {
            get => items[key];
            set => items[key] = value;
        }

        public IEnumerable<Product> Items => items.Values;

        public bool ConstainsKey(string key)
        {
            return items.ContainsKey(key);
        }

        public void RemoveItem(string key)
        {
            items.Remove(key);
        }
    }
}
