using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace coreAPIServerProject.Models;

public partial class CoreWebApiDbContext : DbContext
{
    public CoreWebApiDbContext()
    {
    }

    public CoreWebApiDbContext(DbContextOptions<CoreWebApiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GEHPPMK;Database=CoreWebApiDB;integrated security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D88EFD8333");

            entity.Property(e => e.CustomerCity)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
