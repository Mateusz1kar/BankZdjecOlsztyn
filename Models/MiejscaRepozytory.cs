using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class MiejscaRepozytory : IMiejscaRepozytory
    {
        private readonly AppDbContext _appDbContext;

        
        public MiejscaRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Miejsce PobierzMiejsceId(int miejsceId)
        {
            return _appDbContext.Miejsca.FirstOrDefault(m => m.MiejsceId == miejsceId);
        }

        public IEnumerable<Miejsce> PobierzWszustkieMiejsca()
        {
            return _appDbContext.Miejsca;
        }

        public void dodajMiejsce(Miejsce miejsce)
        {
            _appDbContext.Miejsca.Add(miejsce);
            _appDbContext.SaveChanges();
        }
        public void delMiejsce(int id)
        {
            _appDbContext.Miejsca.Remove(PobierzMiejsceId(id));
            _appDbContext.SaveChanges();
        }
    }
}
