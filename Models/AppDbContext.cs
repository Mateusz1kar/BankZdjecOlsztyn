//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
//=using Microsoft.EntityFrameworkCore;


namespace BankZdjecOlsztyn.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Miejsce> Miejsca { get; set; }
    }
}
