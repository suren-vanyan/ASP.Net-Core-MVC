using ControllersApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersApi.Controllers
{
    public class HomeController : Controller
    {
        public IRepository Repository { get; set; }

        public HomeController(IRepository repo)
        {
            Repository = repo;
        }

        public ViewResult Index() => View(Repository.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            Repository.AddReservation(reservation);
            return RedirectToAction("Index");
        }
    }
}
