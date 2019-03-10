using ControllersAndActions.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    public class HomeController:Controller
    {
        public ViewResult Index() => View("SimpleForm");
        public IActionResult ReceiveForm(string name,string city)
        {
            return new CustomHtmlResult { Content = $"{name} lives in {city}" };
        }
    }
}
