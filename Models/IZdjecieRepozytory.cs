using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface IZdjecieRepozytory
    {
        void dodajZdjecie(Zdjecie z);
        void delZdjecie(int id);
        IEnumerable<Zdjecie> PobierzWszustkieZdjecie();
        Zdjecie PobierzZdjecieId(int ZdjecieId);


    }
}
