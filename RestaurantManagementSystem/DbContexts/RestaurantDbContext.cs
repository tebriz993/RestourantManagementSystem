using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.Entities;

namespace RestaurantManagementSystem.Data
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RestourantManagementSystemDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id); // Id sütununu Primary Key kimi təyin edirik
        }
    }
}
