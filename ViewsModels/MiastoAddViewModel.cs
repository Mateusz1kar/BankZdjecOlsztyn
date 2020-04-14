using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BankZdjecOlsztyn.ViewsModels
{
    public class MiastoAddViewModel
    {

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(188, ErrorMessage = "Nazwa za długa")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(588, ErrorMessage = "Opis za długa")]
        public string Opis { get; set; }

        public IFormFile Zdiencie { get; set; }
        public IFormFile Minniaturka { get; set; }

        [Required(ErrorMessage = "Szerokosc  geograficzna jest wymagana")]
        //[DataType(DataType.)] 
        public double szerokosc { get; set; }

        [Required(ErrorMessage = "wysokosc geograficzna jest wymagana")]
        public double wysokosc { get; set; }
    }
}
