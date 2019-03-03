using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService up)
        {
            uptime = up;
        }
        public ViewResult Index()
         => View(new Dictionary<string, string>
         {
             ["Message "] = "This is t he Index action ",
             ["UpTime"]=$"{uptime.UpTime}ms"

         });
    }
}