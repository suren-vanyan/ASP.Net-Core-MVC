using ExistingDb.Models.Manual;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExistingDb.Controllers
{
    public class ManualController:Controller
    {
        private ManualContext _context;

        public ManualController(ManualContext manualContext)
        {
            this._context = manualContext;
        }

        public IActionResult Index()
        {
            return View(_context.Shoes);
        }
    }
}
