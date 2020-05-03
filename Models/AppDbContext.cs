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
        public DbSet<Tag> Tagi { get; set; }
        public DbSet<MiejsceTag> MiejscTagi { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Miejsce>();
            builder.Entity<Zdjecie>();
            builder.Entity<Tag>();
            builder.Entity<MiejsceTag>()//klucz złożony 
                .HasKey(kluczZlozony => new { kluczZlozony.TagId, kluczZlozony.MiejsceId });
            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}
    }
}
