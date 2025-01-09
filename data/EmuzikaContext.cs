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
        public DbSet<Album> Albumi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pesem>().ToTable("Pesem");
            modelBuilder.Entity<IzvajalecPesem>().ToTable("IzvajalecPesem");
            modelBuilder.Entity<Izvajalec>().ToTable("Izvajalec");
            modelBuilder.Entity<Album>().ToTable("Album");


            modelBuilder.Entity<Album>()
                .Property(a => a.ID)
                .ValueGeneratedNever();
            // Define Izvajalec primary key generation strategy
            modelBuilder.Entity<Izvajalec>()
                .Property(e => e.ID)
                .ValueGeneratedNever();

            // Define Pesem primary key generation strategy
            modelBuilder.Entity<Pesem>()
                .Property(p => p.ID)
                .ValueGeneratedNever();

            // Define Album relationships
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Izvajalec)
                .WithMany(i => i.Albumi)
                .HasForeignKey(a => a.IzvajalecID);

            // Define relationships for IzvajalecPesem with restricted cascade paths
            modelBuilder.Entity<IzvajalecPesem>()
                .HasKey(ip => new { ip.IzvajalecID, ip.PesemID });

            modelBuilder.Entity<IzvajalecPesem>()
                .HasOne(ip => ip.izvajalec)
                .WithMany(i => i.izvajalecPesems)
                .HasForeignKey(ip => ip.IzvajalecID)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascading delete here

            modelBuilder.Entity<IzvajalecPesem>()
                .HasOne(ip => ip.pesem)
                .WithMany(p => p.izvajalecPesems)
                .HasForeignKey(ip => ip.PesemID)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete to avoid multiple cascade paths
        }
    }
}
