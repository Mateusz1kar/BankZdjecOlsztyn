using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class Zdjecie
    {
        public int ZdjecieId { get; set; }

        [Required(ErrorMessage = "URL jest wymagany!")]
        public string Url { get; set; }
        public int MiejsceId { get; set; }
        public Miejsce Miejsce { get; set; }

        internal void CopyTo(FileStream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
