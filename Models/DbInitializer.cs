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
            if (!context.Tagi.Any())
            {
                context.AddRange(
                    new Tag { Nazwa = "Widokowe" },
                    new Tag { Nazwa = "Naukowe " },
                    new Tag { Nazwa = "Dostępne dla niepełnosprawnych ruchowo" },
                    new Tag { Nazwa = "Dla dzieci" },
                    new Tag { Nazwa = "Można z psem" },
                    new Tag { Nazwa = "Historyczne" },
                    new Tag { Nazwa = "Wypoczynkowe" },
                    new Tag { Nazwa = "Młodzieżowe " },
                    new Tag { Nazwa = "Inne" },
                    new Tag { Nazwa = "Rozrywka" },
                    new Tag { Nazwa = "Darmowy wstęp" },
                    new Tag { Nazwa = "Płatny wstęp" },
                    new Tag { Nazwa = "Dla dorosłych" },
                    new Tag { Nazwa = "Ograniczone czasowo" }
                    );
            }
            context.SaveChanges();
        }
    }
}

