
using EF2.Configurations;
using EF2.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EF2.Contexts
{
    internal class EventHubContexts : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OrganizerProfile - Separate Configuration Class
            modelBuilder.ApplyConfiguration(
                new OrganizerProfileConfiguration());

            // Event - Fluent API
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.Property(e => e.Title)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .IsRequired();

                entity.Property(e => e.StartDate)
                      .IsRequired();

                entity.Property(e => e.EndDate)
                      .IsRequired(false);

                entity.Property(e => e.MaxAttendees)
                      .IsRequired();
            });

            // Badge - Fluent API
            modelBuilder.Entity<Badge>(entity =>
            {
                entity.HasKey(b => b.BadgeId);

                entity.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                entity.Property(b => b.IssuedDate)
                      .IsRequired();

                entity.Property(b => b.Tier)
                      .HasConversion<string>();
            });
        }
    }
}
