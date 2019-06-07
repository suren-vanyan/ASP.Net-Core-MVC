using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Store.Models;
using Store.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AdminController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    NormalizedUserName = model.Name,
                    UserName = model.Name,
                    Email = model.Email,
                    Year = model.Year

                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));//ToDo                   
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                    return View(model);

                }

            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(CreateUserViewModel model)
        {

        }


        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(CreateUserViewModel model)
        {

        }
    }
}

