using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface ITrasaTagRepozytory
    {
        void dodajTrasaTag(TrasaTag tt);
        void delTrasaTagTag(int id);
        void delTrasaTagTrasa(int id);
        void delTrasaTag(int idTrasa, int idTag);
        IEnumerable<TrasaTag> PobierzWszustkieTrasyTagi();
        IEnumerable<TrasaTag> PobierzTrasaTagIdTag(int Id);
        IEnumerable<TrasaTag>PobierzTrasaTagIdTrasa(int Id);
        TrasaTag PobierzTrasaTagId(int idTrasa, int idTag);
    }
}
