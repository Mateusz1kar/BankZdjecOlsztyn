using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class Trasa
    {
        public int TrasaID { get; set; }
        [Required(ErrorMessage ="Nazwa trasy jest wymagana")]
        [StringLength(100, ErrorMessage ="Zbyt długa nazwa")]
        public string NazwaTrasy { get; set; }
        public double DlugoscTrasy { get; set; }
        public List<TrasaMiejsce> TrasaMiejsce { get; set; }
        public List<TrasaTag> TrasaTag { get; set; }
    }
    public class TrasaMiejsce
    {
        // public int MiejsceTagId { get; set; }
        public int MiejsceId { get; set; }
        public Miejsce Miejsce { get; set; }

        public int TrasaID { get; set; }
        public Trasa Trasa { get; set; }
        
    }
    
}
