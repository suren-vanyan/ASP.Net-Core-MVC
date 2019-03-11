using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Servicces.Interfaces
{
    public interface IOrder
    {
        void MakeOrder(Book book);
    }
}
