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
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IZdjecieRepozytory _zdjecieRepozytory;
        private readonly ITagRepozytory _tagRepozytory;
        private readonly IMiejscaRepozytory _miejscaRepozytory;
        private readonly IMiejsceTagRepozytory _miejsceTagRepozytory;
        //komunikacja z forderem root
       // private readonly IZdjecieRepozytory _zdjecieRepozytory;
        public AddMiejsceController( IMiejscaRepozytory miejsceRepozytory, IHostingEnvironment hostingEnvironment, ITagRepozytory tagRepozytory, IZdjecieRepozytory zdjecieRepozytory,
            IMiejscaRepozytory miejscaRepozytory, IMiejsceTagRepozytory miejsceTagRepozytory)
        {
            _IMiejscaRepozytory = miejsceRepozytory;
            this.hostingEnvironment = hostingEnvironment;
            _tagRepozytory = tagRepozytory;
            _zdjecieRepozytory = zdjecieRepozytory;
            _miejscaRepozytory = miejscaRepozytory;
            _miejsceTagRepozytory = miejsceTagRepozytory;
                
            //_zdjecieRepozytory = zdjecieRepozytory;
        }


        [HttpGet]
        public IActionResult Index()
        {
            MiastoAddViewModel model = new MiastoAddViewModel();
            model.Tagi = _tagRepozytory.PobierzWszustkieTagi().ToList();
            return View(model);
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
                        MiejsceTag= new List<MiejsceTag>(),
                        szerokosc = model.szerokosc,
                        wysokosc = model.wysokosc
                        

                    };
                    newMiejsce.ZdieciaList.Add(new Zdjecie
                    {
                        Url = uniquefileName

                    });
                    if(model.AreChecked==null)
                    {
                        newMiejsce.MiejsceTag.Add(new MiejsceTag
                        {
                            TagId = 9,
                            Tag = _tagRepozytory.PobierzTagId(9),
                            MiejsceId = newMiejsce.MiejsceId,
                            Miejsce = newMiejsce
                        }); ;
                    }
                    else
                        foreach (int item in model.AreChecked)
                        {
                      
                            newMiejsce.MiejsceTag.Add(new MiejsceTag
                            {
                                TagId = item,
                                Tag= _tagRepozytory.PobierzTagId(item),
                                MiejsceId = newMiejsce.MiejsceId,
                                Miejsce = newMiejsce
                            });;
                        }
                    _IMiejscaRepozytory.dodajMiejsce(newMiejsce);
                    return RedirectToAction("miejsceZgloszone");
                }
                
            }
            model.Tagi = _tagRepozytory.PobierzWszustkieTagi().ToList();
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
        [HttpPost]
        public IActionResult AddZdjecie(MiejsceVM model)
        {
            if (ModelState.IsValid)
            {
                string uniquefileName = null;
                if (model.ZdjecieAdd != null)
                {
                    string uploatFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniquefileName = Guid.NewGuid().ToString() + "_" + model.ZdjecieAdd.FileName;
                    string filePath = Path.Combine(uploatFolder, uniquefileName);
                    model.ZdjecieAdd.CopyTo(new FileStream(filePath, FileMode.Create));
                    var pomM = _IMiejscaRepozytory.PobierzWszustkieMiejsca().ToList();
                    var pomZ = _zdjecieRepozytory.PobierzWszustkieZdjecie().ToList();
                    
                    Miejsce m = _IMiejscaRepozytory.PobierzMiejsceId(model.id2);
                    Zdjecie z = new Zdjecie
                    {
                        Miejsce = m,
                        MiejsceId = m.MiejsceId,
                        Url = uniquefileName
                    };
                    _zdjecieRepozytory.dodajZdjecie(z);
                    //m.ZdieciaList.Add(new Zdjecie
                    //{
                    //    Url = uniquefileName
                    //});

                    var miejsce = _miejscaRepozytory.PobierzMiejsceId(model.id2);
                    var zdjecia = _zdjecieRepozytory.PobierzWszustkieZdjecie();
                    var tagi = _tagRepozytory.PobierzWszustkieTagi();
                    var miejsceTag = _miejsceTagRepozytory.PobierzWszustkieMijescaTagi();

                    model.Miejsca = miejsce;
                    model.Zdjecia = zdjecia.ToList();
                    model.Tagi = tagi.ToList();
                    model.MiejscaTagi = miejsceTag.ToList();
                   
                    return View("../Home/Miejsce", model);
                    //return RedirectToAction("../Home/Miejsce");
                }
            }
             return View();
        }
    }
}
