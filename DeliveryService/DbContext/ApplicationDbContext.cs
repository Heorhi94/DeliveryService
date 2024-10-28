using DeliveryService.Models;
using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            // Seed some sample data
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = Guid.NewGuid().ToString(),
                    Weight = 5.5m,
                    District = "Center",
                    DeliveryTime = DateTime.Now
                }
                // Add more sample data as needed
            );
        }
    }

