using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Models
{
    public interface IМodelStorage
    {
        IEnumerable<Product> Items { get;}
        Product this[string key] { get;set; }
        bool ConstainsKey(string key);
        void RemoveItem(string key);
    }
}
