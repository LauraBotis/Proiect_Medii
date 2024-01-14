using Microsoft.EntityFrameworkCore;
using Proiect_Medii.Models;

namespace Proiect_Medii.Data
{
    public class Proiect_MediiContext : DbContext
    {
        public Proiect_MediiContext(DbContextOptions<Proiect_MediiContext> options)
            : base(options)
        {
        }

        public DbSet<Serviciu> Serviciu { get; set; } = default!;
        public DbSet<Programare>? Programare { get; set; }
        public DbSet<Angajat>? Angajat { get; set; }
        public DbSet<Client>? Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure cascade delete for the Serviciu-Programare relationship
            modelBuilder.Entity<Serviciu>()
                .HasMany(serviciu => serviciu.Programari)
                .WithOne(programare => programare.Serviciu)
                .HasForeignKey(programare => programare.ServiciuID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
