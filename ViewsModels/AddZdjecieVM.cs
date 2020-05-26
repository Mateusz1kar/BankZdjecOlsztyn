using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace BankZdjecOlsztyn.ViewsModels
{
    public class AddZdjecieVM
    {
        public int id2 { get; set; }
        public IFormFile Zdiencie { get; set; }
    }
}
