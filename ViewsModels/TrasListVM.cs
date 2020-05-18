using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;

namespace BankZdjecOlsztyn.ViewsModels
{
    public class TrasListVM
    {
        public List<Trasa> Trasy { get; set; }
        public List<TrasaMiejsce> TrasaMiejsces { get; set; }
        public List<Miejsce> Miejsca { get; set; }
        public List<Zdjecie> Zdjecia { get; set; }
        public List<TrasaTag> TrasaTagi { get; set; }
        public List<Tag> Tagi { get; set; }
        public int id { get; set; }
    }
}
