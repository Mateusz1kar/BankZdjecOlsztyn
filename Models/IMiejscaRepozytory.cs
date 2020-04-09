using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public interface IMiejscaRepozytory
    {
        IEnumerable<Miejsce> PobierzWszustkieMiejsca();
        Miejsce PobierzMiejsceId(int miejsceId);
    }
}
