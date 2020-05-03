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
            _appDbContext.MiejscTagi.Remove(PobierzMiejsceTagIdM(id));
            _appDbContext.SaveChanges();
        }

        public void delMiejsceTagT(int id)
        {
            _appDbContext.MiejscTagi.Remove(PobierzMiejsceTagIdT(id));
            _appDbContext.SaveChanges();
        }

        public void dodajMiejsceTag(MiejsceTag mt)
        {
            _appDbContext.MiejscTagi.Add(mt);
            _appDbContext.SaveChanges();
        }

        public MiejsceTag PobierzMiejsceTagIdM(int Id)
        {
            return _appDbContext.MiejscTagi.FirstOrDefault(mt => mt.MiejsceId == Id);
        }

        public MiejsceTag PobierzMiejsceTagIdT(int Id)
        {
            return _appDbContext.MiejscTagi.FirstOrDefault(mt =>  mt.TagId == Id);
        }

        public MiejsceTag PobierzMiejsceTagId(int IdM, int IdT)
        {
            return _appDbContext.MiejscTagi.FirstOrDefault(mt => mt.MiejsceId == IdM & mt.TagId == IdT);
        }

        public IEnumerable<MiejsceTag> PobierzWszustkieMijescaTagi()
        {
            return _appDbContext.MiejscTagi;
        }
    }
}
