using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankZdjecOlsztyn.Controllers
{
    public class AddMiejsceController : Controller
    {
        private readonly IMiejscaRepozytory _IMiejscaRepozytory;

        public AddMiejsceController(IMiejscaRepozytory miejsceRepozytory)
        {
            _IMiejscaRepozytory = miejsceRepozytory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Miejsce miejsce)
        {
            if (ModelState.IsValid)
            {
                _IMiejscaRepozytory.dodajMiejsce(miejsce);
                return RedirectToAction("miejsceZgloszone");
            }
            return View(miejsce);
        }
        public IActionResult miejsceZgloszone()
        {
            return View();
        }
    }
}
