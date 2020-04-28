using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankZdjecOlsztyn.Models;
using BankZdjecOlsztyn.ViewsModels;

namespace BankZdjecOlsztyn.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMiejscaRepozytory _miejscaRepozytory;
        private readonly IZdjecieRepozytory _zdjecieRepozytory;

        public HomeController(IMiejscaRepozytory miejsceRepository, IZdjecieRepozytory zdjecieRepozytory)
        {
            _miejscaRepozytory = miejsceRepository;
            _zdjecieRepozytory = zdjecieRepozytory;
            //_miejscaRepozytory = new MockMiejscaRepozytory();//bez wstrzykiwania zalerzności
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //zmienna dynamiczm
            //ViewBag.Title="Przegląd miast";
            //mocne typowanie
            var miejsca = _miejscaRepozytory.PobierzWszustkieMiejsca().OrderBy(s => s.Nazwa);
            var zdjecia =_zdjecieRepozytory.PobierzWszustkieZdjecie();
            var homeVM = new HomeViewsModel()
            {
                Tytul = "Przeglad miast",
                Miejsca = miejsca.ToList(),
                Zdjecia = zdjecia.ToList()
            };




            return View(homeVM);
        }
        public IActionResult Mapa()
        {
            return View();
        }
    }
}
