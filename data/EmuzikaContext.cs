using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    public class EmuzikaContext : DbContext
    {
        public EmuzikaContext(DbContextOptions<EmuzikaContext> options) : base(options)
        {
        }

        public DbSet<Pesem> Pesmi { get; set; }
        public DbSet<IzvajalecPesem> IzvajalecPesems { get; set; }
        public DbSet<Izvajalec> Izvajalci { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pesem>().ToTable("Pesem");
            modelBuilder.Entity<IzvajalecPesem>().ToTable("IzvajalecPesem");
            modelBuilder.Entity<Izvajalec>().ToTable("Izvajalec");
        }
    }
}