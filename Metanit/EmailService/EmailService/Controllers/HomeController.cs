using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailService.Controllers
{
    public class HomeController:Controller
    {
        public async Task<IActionResult> SendMessage()
        {
            EmailServices emailService = new EmailServices();
            await emailService.SendEmailAsync("surenvanyan@gmail.com", "Тема письма", "Тест письма: тест!");
            return RedirectToAction("Index");
        }
    }
}
