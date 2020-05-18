using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class TrasaRepozytory : ITrasaRepozytory
    {
        private readonly AppDbContext _appDbContext;

        public TrasaRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void delTrasa(int id)
        {
            _appDbContext.Remove(PobierzTrasa_Id(id));
            _appDbContext.SaveChanges();
        }

        public void dodajTrasa(Trasa trasa)
        {
            _appDbContext.Add(trasa);
            _appDbContext.SaveChanges();
        }

        public Trasa PobierzTrasa_Id(int TrasaId)
        {
            return _appDbContext.Trasy.Find(TrasaId);
        }

        public IEnumerable<Trasa> PobierzWszustkieTrasy()
        {
            return _appDbContext.Trasy.ToList();
        }
    }
}
