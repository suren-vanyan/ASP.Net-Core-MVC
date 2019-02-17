using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult AddUser(User user)
        {
            //string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
            //return Content(userInfo);
            if (ModelState.IsValid)
            {
                string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
                return Content(userInfo);
            }
            return Content($"Количество ошибок: {ModelState.ErrorCount}");

        }

        public IActionResult GetData(string[] items)
        {
            string result = "";
            foreach (var item in items)
                result += item + "; ";
            return Content(result);
        }

        public IActionResult GetPhone(Phone myPhone)
        {
            return Content($"Name: {myPhone?.Name}  Price:{myPhone.Price}  Company: {myPhone?.Manufacturer?.Name}");
        }
    }
}
