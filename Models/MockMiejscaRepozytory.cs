using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankZdjecOlsztyn.Models
{
    public class MockMiejscaRepozytory : IMiejscaRepozytory
    {
        private List<Miejsce> miejsca;

        public MockMiejscaRepozytory()
        {
            if (miejsca == null)
            {
                ZaladujMiejsca();
            }
        }

        private void ZaladujMiejsca()
        {
            miejsca = new List<Miejsce>
            {
                new Miejsce{Id=5,Nazwa="miejsce 1",Opis="opis 1",ZdiencieUrl="", MinniaturkaUrl="", wysokosc=10, szerokosc=2},
                new Miejsce{Id=2,Nazwa="miejsce 2",Opis="opis 2",ZdiencieUrl="", MinniaturkaUrl="", wysokosc=10, szerokosc=2}
            };
        }

        public Miejsce PobierzMiejsceId(int miejsceId)
        {
            return miejsca.FirstOrDefault(m => m.Id == miejsceId);
        }

        public IEnumerable<Miejsce> PobierzWszustkieMiejsca()
        {
            return miejsca;
        }
    }
}
