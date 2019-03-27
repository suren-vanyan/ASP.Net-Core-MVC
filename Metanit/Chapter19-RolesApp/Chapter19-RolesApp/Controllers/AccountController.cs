using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Chapter19_RolesApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chapter19_RolesApp.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext db;
        public AccountController(ApplicationContext context)
        {
            db = context;
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
  
        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var User = db.Users.Include(user => user.Role).FirstOrDefault(user => user.Email == model.Email && user.Password == model.Password);
                if (User != null)
                {
                  await  Authenticate(User);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        // GET: Account/Edit/5
        public ActionResult Register(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password };
                    Role role = await db.Roles.FirstOrDefaultAsync(r => r.Name == "admin");
                    if (user.Role == null)
                        user.Role = role;
                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    await Authenticate(user); // аутентификация

                    return RedirectToAction("About", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);

        }
            
           
        

        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}