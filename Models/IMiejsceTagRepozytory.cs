using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface IMiejsceTagRepozytory
    {
        void dodajMiejsceTag(MiejsceTag mt);
        void delMiejsceTagM(int id);
        void delMiejsceTagT(int id);
        void delMiejsceTag(int idM,int idT); 
        IEnumerable<MiejsceTag> PobierzWszustkieMijescaTagi();
        MiejsceTag PobierzMiejsceTagIdM(int Id);
        MiejsceTag PobierzMiejsceTagIdT(int Id);
        MiejsceTag PobierzMiejsceTagId(int IdM,int IdT);
    }
}
