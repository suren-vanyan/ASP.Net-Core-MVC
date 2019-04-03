using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index => View("Message ","This is the Index action on the Home controller");
    }
}
