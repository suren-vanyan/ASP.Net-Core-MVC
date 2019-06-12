using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
     [Authorize(Roles ="Admin")]
    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        public RoleAdminController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required]string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result =await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
                else
                    AddErrorsFromResult(result);
            }

            return View(name);
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityRole role=await  _roleManager.FindByIdAsync(id);
            List<User> members = new List<User>();
            List<User> noMembers = new List<User>();
            foreach (var user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : noMembers;
                list.Add(user);
            }
            return View(new RoleEditViewModel { Members = members, NonMembers = noMembers, Role = role });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleМodificationViewModel model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
               
                foreach (string userId in model.IdsToAdd ?? new string[] { } )
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user,
                            model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }
                foreach (string userId in model.IdsToDelete ?? new string[] { })
                {
                    User user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user,
                            model.RoleName);
                        if (!result.Succeeded)
                        {
                            AddErrorsFromResult(result);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Edit(model.RoleId);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
           IdentityRole role=await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction(nameof(Index));
                else
                    AddErrorsFromResult(result);
            }
            else { ModelState.AddModelError("", "Role not found"); }

            return View(nameof(Index), _roleManager.Roles);
        }


        private void AddErrorsFromResult(IdentityResult identityResult)
        {
            foreach (var error in identityResult.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
        }
    }
}
