using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Miejsca.Any())
            {
                context.AddRange(
                    new Miejsce { Nazwa = "miejsce 1", Opis = "opis 1", ZdiencieUrl = "", MinniaturkaUrl = "", szerokosc =2, wysokosc = 2 },
                    new Miejsce { Nazwa = "miejsce 2", Opis = "opis 2", ZdiencieUrl = "", MinniaturkaUrl = "", szerokosc = 2, wysokosc = 2 }
                    );
            }
            context.SaveChanges();
        }
    }
}

