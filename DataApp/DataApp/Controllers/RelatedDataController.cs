using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataApp.Models;
using Microsoft.AspNetCore.Mvc;



namespace DataApp.Controllers
{
    public class RelatedDataController : Controller
    {
        private ISupplierRepository _supplierRepository;

        public RelatedDataController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public IActionResult Index => View(_supplierRepository.GetAll());
    }
}
