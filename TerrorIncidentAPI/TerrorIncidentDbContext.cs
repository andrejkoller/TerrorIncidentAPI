using Microsoft.EntityFrameworkCore;
using TerrorIncidentAPI.Models;

namespace TerrorIncidentAPI
{
    public class TerrorIncidentDbContext(DbContextOptions<TerrorIncidentDbContext> options) : DbContext(options)
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incident>().OwnsOne(i => i.Casualties);
            modelBuilder.Entity<Incident>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Incident>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Incident>()
                .Property(i => i.Date)
                .IsRequired();
            modelBuilder.Entity<Incident>()
                .Property(i => i.Description)
                .HasMaxLength(500);
            modelBuilder.Entity<Incident>()
                .HasOne(i => i.Country)
                .WithMany(c => c.Incidents)
                .HasForeignKey(i => i.CountryId);

            modelBuilder.Entity<Country>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Country>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Country>()
                .Property(c => c.IsoCode)
                .HasMaxLength(2);
            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .HasMaxLength(100);
        }
    }
}
