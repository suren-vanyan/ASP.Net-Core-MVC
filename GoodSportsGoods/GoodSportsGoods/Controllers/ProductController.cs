using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodSportsGoods.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodSportsGoods.Controllers
{
    public class ProductController:Controller
    {
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }
        public ViewResult List() => View(repository.Products);
    }
}
