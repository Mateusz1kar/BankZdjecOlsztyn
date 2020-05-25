using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class ZdjenciaRepozytory : IZdjecieRepozytory
    {
        private readonly AppDbContext _appDbContext;
        public ZdjenciaRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void delZdjecie(int id)
        {
            Miejsce miejsce = _appDbContext.Miejsca.Find(id);
            foreach (var item in miejsce.ZdieciaList)
            {
                _appDbContext.Zdjecia.Remove(item);
            }
            _appDbContext.Zdjecia.Remove(PobierzZdjecieId(id));
            _appDbContext.SaveChanges();
        }

        public void dodajZdjecie(Zdjecie z)
        {
            _appDbContext.Zdjecia.Add(z);
            _appDbContext.SaveChanges();
            
        }

        public IEnumerable<Zdjecie> PobierzWszustkieZdjecie()
        {
            return _appDbContext.Zdjecia;
        }

        public Zdjecie PobierzZdjecieId(int ZdjecieId)
        {
            return _appDbContext.Zdjecia.FirstOrDefault(z => z.MiejsceId == ZdjecieId);
        }

        public IEnumerable<Zdjecie> PobierzZdjecieMiejsce(Miejsce m)
        {
            //List<Zdjecie> wynik = new List<Zdjecie>();
            //foreach (var item in m.ZdieciaList)
            //{
            //    wynik.Add(ite)
            //}
            return m.ZdieciaList;
        }
    }
}
