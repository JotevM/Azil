using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Models
{
    public class AzilContext : DbContext
    {
        public DbSet<Azil> Azil{get; set;}
        public DbSet<Udomitelj> Udomitelj{get; set;}
        public DbSet<Cip> Cip{get; set;}
        public DbSet<Zaposleni> Zaposleni{get; set;}
        public DbSet<Zivotinja> Zivotinja{get; set;}
        public DbSet<KartonVakcinacije> KartonVakcinacije{get; set;}
        public AzilContext(DbContextOptions options) : base(options){}
  
    }
}