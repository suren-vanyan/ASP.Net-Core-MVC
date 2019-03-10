using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersAndActions.Controllers
{
    public class DerivedController:Controller
    {
        public ViewResult Index() =>View("Result", $"This is a derived controller");
        public ViewResult Headers()
        {
            return View("DictionaryResult",
                Request.Headers.ToDictionary(kvp => kvp.Key,
                kvp => kvp.Value.First()));
        }
    }
}
