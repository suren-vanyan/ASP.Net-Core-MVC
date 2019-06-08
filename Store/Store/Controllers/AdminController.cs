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
        private UserManager<User> _userManager;
        private IUserValidator<User> _userValidator;
        private IPasswordHasher<User> _passwordHasher;
        private IPasswordValidator<User> _passwordValidator;
        public AdminController(UserManager<User> userManager, IUserValidator<User> userValidator,
            IPasswordHasher<User> passwordHasher, IPasswordValidator<User> passwordValidator)
        {
            _userManager = userManager;
            _userValidator = userValidator;
            _passwordHasher = passwordHasher;
            _passwordValidator = passwordValidator;
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
                EditUserViewModel editUser = new EditUserViewModel { Id = user.Id,UserName=user.UserName ,Email = user.Email, Year = user.Year };
                return View(editUser);
            }
            else
                return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                user.Year = model.Year;
                user.UserName = model.UserName;
                IdentityResult validEmail = await _userValidator.ValidateAsync(_userManager, user);
                if (!validEmail.Succeeded) { AddErrorsFromResult(validEmail); }

                IdentityResult validPass = null;
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                    validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);
                    }
                    else { AddErrorsFromResult(validPass); }
                      
                }
               

                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && validPass.Succeeded && model.Password!=string.Empty))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Index));
                    else
                        AddErrorsFromResult(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }



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

