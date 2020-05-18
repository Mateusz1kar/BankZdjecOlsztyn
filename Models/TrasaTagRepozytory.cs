using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class TrasaTagRepozytory : ITrasaTagRepozytory
    {
        private readonly AppDbContext _appDbContext;
        public TrasaTagRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void delTrasaTag(int idTrasa, int idTag)
        {
            _appDbContext.TrasaTagi.Remove(PobierzTrasaTagId(idTrasa, idTag));
        }

        public void delTrasaTagTag(int id)
        {
            foreach (var item in PobierzTrasaTagIdTag(id))
            {
                _appDbContext.TrasaTagi.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void delTrasaTagTrasa(int id)
        {
            foreach (var item in PobierzTrasaTagIdTrasa(id))
            {
                _appDbContext.TrasaTagi.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void dodajTrasaTag(TrasaTag tt)
        {
            _appDbContext.Add(tt);
            _appDbContext.SaveChanges();
        }

        public TrasaTag PobierzTrasaTagId(int idTrasa, int IdTag)
        {
            return _appDbContext.TrasaTagi.FirstOrDefault(t => t.TagId == IdTag && t.TrasaID == idTrasa);
        }

        public IEnumerable<TrasaTag> PobierzTrasaTagIdTag(int Id)
        {
            return _appDbContext.TrasaTagi.Where(t => t.TagId == Id).ToList();
        }

        public IEnumerable<TrasaTag> PobierzTrasaTagIdTrasa(int Id)
        {
            return _appDbContext.TrasaTagi.Where(t => t.TrasaID == Id).ToList();
        }

        public IEnumerable<TrasaTag> PobierzWszustkieTrasyTagi()
        {
            return _appDbContext.TrasaTagi.ToList();
        }
    }
}
