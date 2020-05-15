﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class Miejsce
    {
        //[BindNever]
        public int MiejsceId { get; set; }

        [Required(ErrorMessage ="Nazwa jest wymagana")]
        [StringLength(188,ErrorMessage ="Nazwa za długa")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany")]
        [StringLength(588, ErrorMessage = "Opis za długa")]
        public string Opis { get; set; }

        public List<MiejsceTag> MiejsceTag { get; set; }
        public List<TrasaMiejsce> TrasyMiejsca { get; set; }
        public List<Zdjecie> ZdieciaList { get; set; }

        [Required(ErrorMessage = "Szerokosc  geograficzna jest wymagana")]
        //[DataType(DataType.)]
        public double szerokosc { get; set; }

        [Required(ErrorMessage = "wysokosc geograficzna jest wymagana")]
        public double wysokosc { get; set; }

    }
}
