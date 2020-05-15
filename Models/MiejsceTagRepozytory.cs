using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class MiejsceTagRepozytory : IMiejsceTagRepozytory
    {
        private readonly AppDbContext _appDbContext;
        public MiejsceTagRepozytory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void delMiejsceTag(int idM, int IdT)
        {
            _appDbContext.MiejscTagi.Remove(PobierzMiejsceTagId(idM,IdT));
            _appDbContext.SaveChanges();

        }

        public void delMiejsceTagM(int id)
        {
            //_appDbContext.MiejscTagi.Remove(PobierzMiejsceTagIdM(id));
            foreach (var item in PobierzMiejsceTagIdM(id))
            {
                _appDbContext.MiejscTagi.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void delMiejsceTagT(int id)
        {
            //_appDbContext.MiejscTagi.Remove(PobierzMiejsceTagIdT(id));
            foreach (var item in PobierzMiejsceTagIdT(id))
            {
                _appDbContext.MiejscTagi.Remove(item);
            }
            _appDbContext.SaveChanges();
        }

        public void dodajMiejsceTag(MiejsceTag mt)
        {
            _appDbContext.MiejscTagi.Add(mt);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<MiejsceTag> PobierzMiejsceTagIdM(int Id)
        {
            return _appDbContext.MiejscTagi.Where(mt => mt.MiejsceId == Id);
        }

        public IEnumerable<MiejsceTag> PobierzMiejsceTagIdT(int Id)
        {
            return _appDbContext.MiejscTagi.Where(mt =>  mt.TagId == Id);
        }

        public MiejsceTag PobierzMiejsceTagId(int IdM, int IdT)
        {
            return _appDbContext.MiejscTagi.FirstOrDefault(mt => mt.MiejsceId == IdM & mt.TagId == IdT);
        }

        public IEnumerable<MiejsceTag> PobierzWszustkieMijescaTagi()
        {
            return _appDbContext.MiejscTagi;
        }

        MiejsceTag IMiejsceTagRepozytory.PobierzMiejsceTagIdM(int Id)
        {
            throw new NotImplementedException();
        }

        MiejsceTag IMiejsceTagRepozytory.PobierzMiejsceTagIdT(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
