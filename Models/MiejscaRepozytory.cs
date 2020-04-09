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
            return _appDbContext.Miejsca.FirstOrDefault(m => m.Id == miejsceId);
        }

        public IEnumerable<Miejsce> PobierzWszustkieMiejsca()
        {
            return _appDbContext.Miejsca;
        }
    }
}
