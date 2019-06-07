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
        public IActionResult Index() => View(_userManager.Users);

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
        public async Task<IActionResult> Edit(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                EditUserViewModel editUser = new EditUserViewModel { Id = user.Id, Email = user.Email, Year = user.Year,Password=user.PasswordHash };
                return View(editUser);
            }
            else
                return RedirectToAction(nameof(Index));
        }


        //[HttpPut]
        //public async Task<IActionResult> Edit(EditUserViewModel model)
        //{

        //}



        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery(Name = "ID")] string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult identityResult = await _userManager.DeleteAsync(user);
                if (identityResult.Succeeded)
                    RedirectToAction(nameof(Index));
                else
                    AddErrorsFromResult(identityResult);
            }
            ModelState.AddModelError("", "User Not Found");
            return View(nameof(Index), _userManager.Users);
        }

        public void AddErrorsFromResult(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }
    }
}

