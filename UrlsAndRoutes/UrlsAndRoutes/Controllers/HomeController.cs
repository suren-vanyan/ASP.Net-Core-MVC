using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View("Result",
         new Result
         {
             Controller = nameof(HomeController),
             Action = nameof(Index)
         });

        public ViewResult CustomVariabe(string id)
        {
            Result r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(CustomVariabe)
            };
            r.Data["id"] = id??"No Value";
            r.Data["catchall"] = RouteData.Values["catchall"];
            return View("Result", r);
        }
            
            
        
        

    }

}


