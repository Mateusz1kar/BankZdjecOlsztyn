using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface ITagRepozytory
    {

        void dodajTag(Tag tag);
        void delTag(int id);
        IEnumerable<Tag> PobierzWszustkieTagi();
        Tag PobierzTagId(int Id);
    }
}
