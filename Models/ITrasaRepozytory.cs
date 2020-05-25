using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface ITrasaRepozytory
    {
        void dodajTrasa(Trasa trasa);
        void delTrasa(int id);
        IEnumerable<Trasa> PobierzWszustkieTrasy();
        Trasa PobierzTrasa_Id(int TrasaId);
    }
}
