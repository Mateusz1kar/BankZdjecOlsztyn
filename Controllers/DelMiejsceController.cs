using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankZdjecOlsztyn.Controllers
{

    public class DelMiejsceController : Controller
    {

        private readonly ITrasaRepozytory _trasaRepozytory;
        private readonly IMiejscaRepozytory _miejscaRepozytory;
        private readonly IMiejsceTagRepozytory _miejsceTagRepozytory;
       
        private readonly ITagRepozytory _tagRepozytory;
        private readonly ITrasaTagRepozytory _trasaTagRepozytory;
        private readonly ITrasaMiejsceRepozytory _trasaMiejsceRepozytory;
        private readonly IZdjecieRepozytory _zdjecieRepozytory;
        //komunikacja z forderem root
        // private readonly IZdjecieRepozytory _zdjecieRepozytory;
        public DelMiejsceController(ITrasaRepozytory trasaRepozytory , ITagRepozytory tagRepozytory, IZdjecieRepozytory zdjecieRepozytory,
            IMiejscaRepozytory miejscaRepozytory, ITrasaTagRepozytory trasaTagRepozytory, ITrasaMiejsceRepozytory trasaMiejsceRepozytory, IMiejsceTagRepozytory miejsceTagRepozytory)
        {
            _trasaRepozytory = trasaRepozytory;
            _tagRepozytory = tagRepozytory;
            _miejscaRepozytory = miejscaRepozytory;
            _trasaTagRepozytory = trasaTagRepozytory;
            _trasaMiejsceRepozytory = trasaMiejsceRepozytory;
            _miejsceTagRepozytory = miejsceTagRepozytory;
            _zdjecieRepozytory = zdjecieRepozytory;
        }
        // GET: /<controller>/

        [HttpPost]
        public IActionResult Delete(int id2)
        {
            // HttpPostAttribute x = new HttpPostAttribute["id"];
            _trasaMiejsceRepozytory.delTrasaMiejsce_Miejsce(id2);

            _miejscaRepozytory.delMiejsce( id2);
            return Redirect("../Home/Index");

        }
    }
}
