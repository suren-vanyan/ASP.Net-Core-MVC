using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //public IRepository Repository { get;set; } = TypeBroker.Repository;
        //public ViewResult Index() => View(Repository.Products);
        private IRepository repository;
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index() => View(repository.Products);
    }
}
