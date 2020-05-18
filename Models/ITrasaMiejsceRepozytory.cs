using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface ITrasaMiejsceRepozytory
    {
        void dodajTrasaMiejsce(TrasaMiejsce tm);
        void delTrasaMiejsce_Miejsce(int id);
        void delTrasaMiejsce_Trasa(int id);
        void delTrasaMiejsce(int idTrasa, int idMiejsce);
        IEnumerable<TrasaMiejsce> PobierzWszustkieTrasyMiejsca();
        IEnumerable<TrasaMiejsce> PobierzTrasaMiejsce_IdMiejsce(int Id);
        IEnumerable<TrasaMiejsce> PobierzTrasaMiejsce_IdTrasa(int Id);
        TrasaMiejsce PobierzTrasaMiejsceId(int idTrasa, int idMiejsce);
    }
}
