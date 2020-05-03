using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class Tag
    {
        public int TagId { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana!")]
        public string Nazwa { get; set; }

        public List<MiejsceTag> MiejsceTag { get; set; }
        
    }
    public class MiejsceTag
    {
       // public int MiejsceTagId { get; set; }
        public int MiejsceId { get; set; }
        public Miejsce Miejsce { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
