using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class TrasaMiejsceRepozytory : ITrasaMiejsceRepozytory
    {
        private readonly AppDbContext _appDbContext;

        public TrasaMiejsceRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void delTrasaMiejsce(int idTrasa, int idMiejsce)
        {
            _appDbContext.Remove(PobierzTrasaMiejsceId(idTrasa,idMiejsce));
            _appDbContext.SaveChanges();
        }

        public void delTrasaMiejsce_Miejsce(int id)
        {
            foreach (var item in PobierzTrasaMiejsce_IdMiejsce(id))
            {
                _appDbContext.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void delTrasaMiejsce_Trasa(int id)
        {
            foreach (var item in PobierzTrasaMiejsce_IdTrasa(id))
            {
                _appDbContext.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void dodajTrasaMiejsce(TrasaMiejsce tm)
        {
            _appDbContext.TrasaMiejsca.Add(tm);
        }

        public TrasaMiejsce PobierzTrasaMiejsceId(int idTrasa, int idMiejsce)
        {
            return _appDbContext.TrasaMiejsca.FirstOrDefault(tm => tm.MiejsceId == idMiejsce && tm.TrasaID == idTrasa);
        }

        public IEnumerable<TrasaMiejsce> PobierzTrasaMiejsce_IdMiejsce(int Id)
        {
            return _appDbContext.TrasaMiejsca.Where(tm => tm.MiejsceId == Id).ToList();
        }

        public IEnumerable<TrasaMiejsce> PobierzTrasaMiejsce_IdTrasa(int Id)
        {
            return _appDbContext.TrasaMiejsca.Where(tm => tm.TrasaID == Id).ToList();
        }

        public IEnumerable<TrasaMiejsce> PobierzWszustkieTrasyMiejsca()
        {
            return _appDbContext.TrasaMiejsca.ToList();
        }
    }
}
