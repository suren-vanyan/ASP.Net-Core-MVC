using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private IHttpContextAccessor _accessor;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accessor = accessor;
        }
      
        [AllowAnonymous]
        public IActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]
        public string Test()
        {
            string remoteIpAddress =  HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                remoteIpAddress = Request.Headers["X-Forwarded-For"];
            return remoteIpAddress;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User {  PhoneNumber = model.Phone, Email = model.Email, UserName = model.Name, Year = model.Year };
                
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                   
                    await _signInManager.SignInAsync(user, true);
                    return RedirectToAction("Index", "Admin");//ToDo
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl )
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                if (model.UserName.Contains("@"))
                    user = await _userManager.FindByEmailAsync(model.UserName);
                else
                    user = await _userManager.FindByNameAsync(model.UserName);

                if (user!= null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false)).Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl??"/");
                          
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin");//ToDo
                        }
                    }

                }

            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(model);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
