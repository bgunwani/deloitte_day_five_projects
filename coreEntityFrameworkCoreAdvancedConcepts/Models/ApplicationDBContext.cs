using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreEntityFrameworkCoreAdvancedConcepts.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GEHPPMK;Database=trainingdb;integrated security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.User_Id);

            // Primary Key for Company
            modelBuilder.Entity<Company>()
                .HasKey(c => c.Id);

            // Primary Key for Employee
            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

            // One-To-Many Relationship between Company and Employee
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company);

            // Alternatively, One-To-Many Relationship between Company and Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(e => e.Employees);

            // Configuration for Many-To-Many Relationship (Book, Category)

            modelBuilder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);

            modelBuilder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

        }

    }
}
