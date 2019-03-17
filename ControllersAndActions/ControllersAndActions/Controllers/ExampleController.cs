using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    public class ExampleController:Controller
    {
        public ViewResult Index() => View(DateTime.Now);
    }
}
