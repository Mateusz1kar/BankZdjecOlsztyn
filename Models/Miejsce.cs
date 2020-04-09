using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class Miejsce
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string ZdiencieUrl { get; set; }
        public string MinniaturkaUrl { get; set; }
        public double szerokosc { get; set; }
        public double wysokosc { get; set; }

    }
}
