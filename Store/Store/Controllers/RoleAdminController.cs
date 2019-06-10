using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    public class RoleAdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleAdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
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
