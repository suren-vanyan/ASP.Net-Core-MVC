using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Chapter19_RolesApp.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Chapter19_RolesApp.Controllers
{
    public class HomeController : Controller
    {

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"ваша роль: {role}");
        }

        [Authorize(Roles = "admin")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

    }
}
