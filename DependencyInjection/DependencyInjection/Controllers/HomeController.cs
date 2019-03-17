using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Controllers
{
    class HomeController:Controller
    {
        public ViewResult Index() => View();
        
    }
}
