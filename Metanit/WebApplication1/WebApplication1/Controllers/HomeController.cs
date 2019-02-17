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
        //public IActionResult AddUser(User user)
        //{
        //    //string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
        //    //return Content(userInfo);
        //    if (ModelState.IsValid)
        //    {
        //        string userInfo = $"Id: {user.Id}  Name: {user.Name}  Age: {user.Age}  HasRight: {user.HasRight}";
        //        return Content(userInfo);
        //    }
        //    return Content($"Количество ошибок: {ModelState.ErrorCount}");

        //}

        public IActionResult AddUser1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser1([FromQuery] User user)
        {
            string userInfo = $"Name: {user.Name}  Age: {user.Age}";
            return Content(userInfo);
        }

        public IActionResult AddUser2([FromBody] User user)
        {
            string userInfo = $"Name: {user.Name}  Age: {user.Age}";
            return Content(userInfo);
        }

        public IActionResult GetUserAgent([FromHeader(Name = "User-Agent")] string userAgent)
        {
            return Content(userAgent);
        }


        public IActionResult GetData(string[] items)
        {
            string result = "";
            foreach (var item in items)
                result += item + "; ";
            return Content(result);
        }

        public IActionResult GetPhone1(Phone myPhone)
        {
            if (ModelState.IsValid)
                return Content($"Name: {myPhone?.Name}  Price:{myPhone.Price}  Company: {myPhone?.Manufacturer?.Name}");
            return Content($"Count of Eror  {ModelState.ErrorCount}");
        }

        public IActionResult GetPhone([Bind("Name,Price,Manufacturer")]Phone myPhone)
        {
            if (ModelState.IsValid)
                return Content($"Name: {myPhone?.Name}  Price:{myPhone.Price}  Company: {myPhone?.Manufacturer?.Name}");
            return Content($"Count of Eror  {ModelState.ErrorCount}");
        }

    }
}
