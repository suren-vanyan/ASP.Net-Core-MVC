using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebScrapping.Models;
using Newtonsoft.Json;

namespace WebScrapping.Controllers
{
    [Produces("application/json")]
   // [Route("~/api/CompaniesController")]
    public class CompaniesController : Controller
    {
        private readonly WebScrappingContext _context;

        public CompaniesController(WebScrappingContext context)
        {
            _context = context;
            
        }

        // GET: Companies
        [Route("~/api/Index")]
        [HttpGet]
        public async Task<JsonResult> Index()
        {
            //return View(await _context.Company.ToListAsync());
           return Json(await _context.Company.ToListAsync());
        }

        // Companies/GetAllCompanies
        [Route("~/api/GetCompanyName")]
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var companies =await _context.Company.Select(comp=>comp.Name).ToListAsync();
            return  Json(companies);
        }

        // GET: Companies/Details/5
        [Route("~/api/Details/{id}")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id=1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        [Route("~/api/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("~/api/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Industry,Type,NumbOfEmployees,DataOfFoundation,AboutCompany,WebSite,Adress")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        [Route("~/api/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> Edit(int? id=1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("~/api/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Industry,Type,NumbOfEmployees,DataOfFoundation,AboutCompany,WebSite,Adress")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        [Route("~/api/Delete/{id}")]
        [HttpGet]      
        public async Task<IActionResult> Delete(int? id=1)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [Route("~/api/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id=1)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.Id == id);
        }
    }
}
