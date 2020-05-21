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
        private readonly ITagRepozytory _tagRepozytory;
        private readonly IMiejsceTagRepozytory _miejsceTagRepozytory;
        public HomeController(IMiejscaRepozytory miejsceRepository, IZdjecieRepozytory zdjecieRepozytory, ITagRepozytory tagRepozytory, IMiejsceTagRepozytory miejsceTagRepozytory)
        {
            _miejscaRepozytory = miejsceRepository;
            _zdjecieRepozytory = zdjecieRepozytory;
            _tagRepozytory = tagRepozytory;
            _miejsceTagRepozytory = miejsceTagRepozytory;
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
            var tagi = _tagRepozytory.PobierzWszustkieTagi();
            var miejsceTag = _miejsceTagRepozytory.PobierzWszustkieMijescaTagi();
            var homeVM = new HomeViewsModel()
            {
                Tytul = "Przeglad miast",
                Miejsca = miejsca.ToList(),
                Zdjecia = zdjecia.ToList(),
                Tagi = tagi.ToList(),
                MiejscaTagi = miejsceTag.ToList(),
                
                

            };




            return View(homeVM);
        }
        public IActionResult Mapa()
        {
            var miejsca = _miejscaRepozytory.PobierzWszustkieMiejsca().OrderBy(s => s.Nazwa);
            var zdjecia = _zdjecieRepozytory.PobierzWszustkieZdjecie();
            var homeVM = new HomeViewsModel()
            {
                Tytul = "Przeglad miast",
                Miejsca = miejsca.ToList(),
                Zdjecia = zdjecia.ToList()
                
            };
            return View(homeVM);
        }
        public IActionResult Miejsce(int id2)
        {
            var miejsce = _miejscaRepozytory.PobierzMiejsceId(id2);
            var zdjecia = _zdjecieRepozytory.PobierzWszustkieZdjecie();
            var tagi = _tagRepozytory.PobierzWszustkieTagi();
            var miejsceTag = _miejsceTagRepozytory.PobierzWszustkieMijescaTagi();
            var newMiejsceVM = new MiejsceVM()
            {
                Miejsca = miejsce,
                Zdjecia = zdjecia.ToList(),
                Tagi = tagi.ToList(),
                MiejscaTagi = miejsceTag.ToList(),
            };
            return View(newMiejsceVM);
        }
    }
}
