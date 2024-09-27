using Microsoft.EntityFrameworkCore;
using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EdenTravels.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Adding DbSets here for entities
        public DbSet<User> Users { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<PassportVisaStatus> PassportVisaStatuses { get; set; }
        public DbSet<Customization> Customizations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Cancellation> Cancellations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations go here
        }
    }
}