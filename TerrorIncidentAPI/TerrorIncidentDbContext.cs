using Microsoft.EntityFrameworkCore;
using TerrorIncidentAPI.Models;

namespace TerrorIncidentAPI
{
    public class TerrorIncidentDbContext(DbContextOptions<TerrorIncidentDbContext> options) : DbContext(options)
    {
        public DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Incident>().OwnsOne(i => i.Casualties);
            modelBuilder.Entity<Incident>().OwnsOne(i => i.Attacker);

            modelBuilder.Entity<Incident>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Incident>()
                .Property(i => i.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Incident>()
                .Property(i => i.Date)
                .IsRequired();
            modelBuilder.Entity<Incident>()
                .Property(i => i.Country)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Incident>()
                .Property(i => i.Description)
                .HasMaxLength(500);
        }
    }
}
