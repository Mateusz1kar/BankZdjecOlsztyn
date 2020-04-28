using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;
using BankZdjecOlsztyn.ViewsModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankZdjecOlsztyn.Controllers
{
    public class AddMiejsceController : Controller
    {
        private readonly IMiejscaRepozytory _IMiejscaRepozytory;
        private readonly IHostingEnvironment hostingEnvironment; //komunikacja z forderem root
       // private readonly IZdjecieRepozytory _zdjecieRepozytory;
        public AddMiejsceController( IMiejscaRepozytory miejsceRepozytory, IHostingEnvironment hostingEnvironment)
        {
            _IMiejscaRepozytory = miejsceRepozytory;
            this.hostingEnvironment = hostingEnvironment;
            //_zdjecieRepozytory = zdjecieRepozytory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MiastoAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniquefileName = null;
                if (model.Zdiencie != null)
                {
                    string uploatFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniquefileName = Guid.NewGuid().ToString() + "_" + model.Zdiencie.FileName;
                    string filePath = Path.Combine(uploatFolder, uniquefileName);
                    model.Zdiencie.CopyTo(new FileStream(filePath, FileMode.Create));
                  
                    //_zdjecieRepozytory.dodajZdjecie(newZdjecie);
                    
                    Miejsce newMiejsce = new Miejsce
                    {
                        Nazwa = model.Nazwa,
                        Opis = model.Opis,
                        ZdieciaList = new List<Zdjecie>(),
                        szerokosc = model.szerokosc,
                        wysokosc = model.wysokosc
                    };
                    newMiejsce.ZdieciaList.Add(new Zdjecie
                    {
                        Url = uniquefileName

                    });
                    _IMiejscaRepozytory.dodajMiejsce(newMiejsce);
                    return RedirectToAction("miejsceZgloszone");
                }
                
            }
            return View(model);
        }
        //public IActionResult Index(Miejsce miejsce)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _IMiejscaRepozytory.dodajMiejsce(miejsce);
        //        return RedirectToAction("miejsceZgloszone");
        //    }
        //    return View(miejsce);
        //}
        public IActionResult miejsceZgloszone()
        {
            return View();
        }
    }
}
