using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankZdjecOlsztyn.ViewsModels
{
    public class TrasAddVM
    {

        public int TrasaID { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(188, ErrorMessage = "Nazwa za długa")]
        public string NazwaTrasy { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        //[StringLength(588, ErrorMessage = "Opis za długa")]
        //public string Opis { get; set; }

        //public IFormFile Zdiencie { get; set; }


        
        
       

        
        public double DlugoscTrasy { get; set; }

        public List<Tag> Tagi { get; set; }
        public List<TrasaMiejsce> TrasaMiejsca { get; set; }
        public List<Miejsce> miejsca { get; set; }

        //[HtmlAttributeName("asp-checklistbox")]
        //public IEnumerable<SelectListItem> Items { get; set; }
        [BindProperty]
        public List<int> AreChecked { get; set; }

        [BindProperty]
        public List<int> AreCheckedMiejsca { get; set; }
    }
}

