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
        private ProductTotalizer totalizer;
        public HomeController(IRepository repo,ProductTotalizer totalizer)
        {
            repository = repo;
            this.totalizer = totalizer;
        }
       
        public ViewResult Index()
        {
            ViewBag.HomeController=repository.ToString();
            ViewBag.Total = totalizer.Repository.ToString();
            return View(repository.Products);
        }
    }
}
