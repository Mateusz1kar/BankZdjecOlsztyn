using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class TagRepozytory : ITagRepozytory
    {
        private readonly AppDbContext _appDbContext;
        public TagRepozytory(AppDbContext appDbContex)
        {
            _appDbContext = appDbContex;
        }
        public void delTag(int id)
        {
            _appDbContext.Tagi.Remove(PobierzTagId(id));
            _appDbContext.SaveChanges();
        }

        public void dodajTag(Tag tag)
        {
            _appDbContext.Tagi.Add(tag);
            _appDbContext.SaveChanges();
        }

        public Tag PobierzTagId(int Id)
        {
            return _appDbContext.Tagi.FirstOrDefault(t => t.TagId == Id);

        }


        IEnumerable<Tag> ITagRepozytory.PobierzWszustkieTagi()
        {
            return _appDbContext.Tagi;
        }
    }
}
