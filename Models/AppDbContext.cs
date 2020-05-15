//using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//=using Microsoft.EntityFrameworkCore;


namespace BankZdjecOlsztyn.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Miejsce> Miejsca { get; set; }
        public DbSet<Tag> Tagi { get; set; }
        public DbSet<MiejsceTag> MiejscTagi { get; set; }
        public DbSet<Zdjecie> Zdjecia { get; set; }
        public DbSet<Trasa> Trasy { get; set; }
        public DbSet<TrasaTag> TrasaTagi { get; set; }
        public DbSet<TrasaMiejsce> TrasaMiejsca { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Miejsce>();
            builder.Entity<Zdjecie>();
            builder.Entity<Tag>();
            builder.Entity<Trasa>();
            builder.Entity<MiejsceTag>()//klucz złożony 
                .HasKey(kluczZlozony => new { kluczZlozony.TagId, kluczZlozony.MiejsceId });
            builder.Entity<TrasaMiejsce>()//klucz złożony 
                .HasKey(kluczZlozony => new { kluczZlozony.TrasaID, kluczZlozony.MiejsceId });
            builder.Entity<TrasaTag>()//klucz złożony 
               .HasKey(kluczZlozony => new { kluczZlozony.TrasaID, kluczZlozony.TagId });
            base.OnModelCreating(builder);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //}
    }
}
