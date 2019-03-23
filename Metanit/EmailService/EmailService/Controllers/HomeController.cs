using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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
            ViewData["Message"] = "Your contact page";
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Junior C# .Net Developer", "surenvanyan@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Vanyan Suren", "vanyansuren@gmail.com"));
            emailMessage.Subject = "I learnt to send a email using asp.net core 2.0";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = "I am using MailKit"
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 487, false);
                await client.AuthenticateAsync("surenvanyan@gmail.com", "stepanosaraqelyan18631893");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
            //EmailServices emailService = new EmailServices();
            //await emailService.SendEmailAsync("surenvanyan@gmail.com", "Тема письма", "Тест письма: тест!");
            //return RedirectToAction("Index");
            return Ok(emailMessage);
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {

            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Junior C# .Net Developer", "vanyansuren@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Suren", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 25, false);
                await client.AuthenticateAsync("vanyansuren@gmail.com", "password");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }

        }
    }
}
