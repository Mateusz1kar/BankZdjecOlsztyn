﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankZdjecOlsztyn.Models;

namespace BankZdjecOlsztyn.ViewsModels
{
    public class HomeViewsModel
    {
        public string Tytul { get; set; }
        public int id2 { get; set; }
        public List<Miejsce> Miejsca { get; set; }
        public List<Zdjecie> Zdjecia { get; set; }
        public List<MiejsceTag> MiejscaTagi { get; set; }
        public List<Tag> Tagi { get; set; }
        public int I_Net { get; set; }
       
    }
}
