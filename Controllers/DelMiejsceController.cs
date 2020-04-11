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

        private readonly IMiejscaRepozytory _IMiejscaRepozytory;
        public DelMiejsceController(IMiejscaRepozytory miejscaRepozytory)
        {
            _IMiejscaRepozytory = miejscaRepozytory;
        }
        // GET: /<controller>/

        [HttpPost]
        public IActionResult Delete(int id2)
        {
           // HttpPostAttribute x = new HttpPostAttribute["id"];
            _IMiejscaRepozytory.delMiejsce( id2);
            return Redirect("../Home/Index");

        }
    }
}
