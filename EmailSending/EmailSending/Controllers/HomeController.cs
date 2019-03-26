using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmailSending.Models;
using MimeKit;
using MailKit.Net.Smtp;

namespace EmailSending.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewData["Message"] = "Your contact page";
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Junior C# .Net Developer", "surenvanyan@gmail.com"));
                emailMessage.To.Add(new MailboxAddress("Vanyan Suren", "surenvanyan.xtech@gmail.com"));
                emailMessage.Subject = "I learnt to send a email using asp.net core 2.0";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = "I am using MailKit"
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 587, true);
                    await client.AuthenticateAsync("surenvanyan@gmail.com", "haneci))");


                    await client.SendAsync(emailMessage);

                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw;
            }


            return null;
           
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
