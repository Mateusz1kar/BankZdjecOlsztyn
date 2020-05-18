using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;
using BankZdjecOlsztyn.ViewsModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankZdjecOlsztyn.Controllers
{
    public class TrasController : Controller
    {
        private readonly ITrasaRepozytory _trasaRepozytory;
        private readonly IMiejscaRepozytory _miejscaRepozytory;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ITagRepozytory _tagRepozytory;
        private readonly ITrasaTagRepozytory _trasaTagRepozytory;
        private readonly ITrasaMiejsceRepozytory _trasaMiejsceRepozytory;
        //komunikacja z forderem root
        // private readonly IZdjecieRepozytory _zdjecieRepozytory;
        public TrasController(ITrasaRepozytory trasaRepozytory, IHostingEnvironment hostingEnvironment, ITagRepozytory tagRepozytory,
            IMiejscaRepozytory miejscaRepozytory, ITrasaTagRepozytory trasaTagRepozytory, ITrasaMiejsceRepozytory trasaMiejsceRepozytory)
        {
            _trasaRepozytory = trasaRepozytory;
            this.hostingEnvironment = hostingEnvironment;
            _tagRepozytory = tagRepozytory;
            _miejscaRepozytory = miejscaRepozytory;
            _trasaTagRepozytory=  trasaTagRepozytory;
            _trasaMiejsceRepozytory = trasaMiejsceRepozytory;
            //_zdjecieRepozytory = zdjecieRepozytory;
        }
        // GET: /<controller>/
        public IActionResult AddTras()
        {
            TrasAddVM trasAddVM = new TrasAddVM();
            trasAddVM.Tagi = _tagRepozytory.PobierzWszustkieTagi().ToList();
            trasAddVM.miejsca = _miejscaRepozytory.PobierzWszustkieMiejsca().ToList();
            return View(trasAddVM);
        }
        [HttpPost]
        public IActionResult AddTras(TrasAddVM model)
        {
            if (ModelState.IsValid)
            {
               

                Trasa newTrasa = new Trasa
                {
                    NazwaTrasy = model.NazwaTrasy,
                    //Opis = model.Opis,
                    TrasaMiejsce = new List<TrasaMiejsce>(),
                    TrasaTag = new List<TrasaTag>(),
                    DlugoscTrasy = model.DlugoscTrasy,
                    


                };

                if (model.AreChecked == null)
                {
                    newTrasa.TrasaTag.Add(new TrasaTag
                    {
                        TagId = 9,
                        Tag = _tagRepozytory.PobierzTagId(9),
                        TrasaID = newTrasa.TrasaID,
                        Trasa = newTrasa
                    }); ;
                }
                else
                    foreach (int item in model.AreChecked)
                    {

                        newTrasa.TrasaTag.Add(new TrasaTag
                        {
                            TagId = item,
                            Tag = _tagRepozytory.PobierzTagId(item),
                            TrasaID = newTrasa.TrasaID,
                            Trasa = newTrasa
                        }); ;
                    }
                if (model.AreCheckedMiejsca != null)
                {
                    foreach (int item in model.AreCheckedMiejsca)
                    {

                        newTrasa.TrasaMiejsce.Add(new TrasaMiejsce
                        {
                            MiejsceId = item,
                            Miejsce = _miejscaRepozytory.PobierzMiejsceId(item),
                            TrasaID = newTrasa.TrasaID,
                            Trasa = newTrasa
                        }); ;
                    }
                }
                
                _trasaRepozytory.dodajTrasa(newTrasa);
                return RedirectToAction("TrasList");




            }
            model.Tagi = _tagRepozytory.PobierzWszustkieTagi().ToList();
            model.miejsca = _miejscaRepozytory.PobierzWszustkieMiejsca().ToList();
            return View(model);
        }

        public IActionResult TrasList()
        {
            TrasListVM newTrasList = new TrasListVM();
            newTrasList.Trasy = _trasaRepozytory.PobierzWszustkieTrasy().ToList();
            newTrasList.Tagi = _tagRepozytory.PobierzWszustkieTagi().ToList();
            newTrasList.Miejsca = _miejscaRepozytory.PobierzWszustkieMiejsca().ToList();
            newTrasList.TrasaTagi = _trasaTagRepozytory.PobierzWszustkieTrasyTagi().ToList();
            newTrasList.TrasaMiejsces = _trasaMiejsceRepozytory.PobierzWszustkieTrasyMiejsca().ToList();

           // newTrasList.TrasaMiejsces= _tras
            return View(newTrasList);
        }

        public IActionResult DeleteTras(int id)
        {
            _trasaRepozytory.delTrasa(id);
            return Redirect("../Tras/TrasList");
        }
    }
}
