using Filters.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
       
        [Profile]
        public IActionResult Index()
        {       
                return View("Message", "This is the Index action on the Home controller");          
        }

        [Profile]
        public IActionResult SecondAction()
        {        
                return View("Message", "This is the Index action on the Home controller");         
        }
    }
}
