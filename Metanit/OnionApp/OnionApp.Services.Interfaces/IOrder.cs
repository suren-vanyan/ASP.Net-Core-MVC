using OnionApp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionApp.Services.Interfaces
{
    public interface IOrder
    {
        void MakeOrder(Book book);
    }
}
