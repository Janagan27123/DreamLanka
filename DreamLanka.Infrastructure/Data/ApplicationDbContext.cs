using DreamLanka.Domain.Common;
using DreamLanka.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamLanka.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // DbSets
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Vendor> Vendors { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<DeliveryPartner> DeliveryPartners { get; set; }
    public DbSet<OrderTracking> OrderTrackings { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Global Query Filter for Soft Delete - Add this FIRST
        modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Product>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Order>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Vendor>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<DeliveryPartner>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<Address>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<OrderItem>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<OrderTracking>().HasQueryFilter(e => !e.IsDeleted);
        modelBuilder.Entity<ProductReview>().HasQueryFilter(e => !e.IsDeleted);

        // User configuration
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.PhoneNumber).IsUnique();
        });

        // Address configuration
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Street).IsRequired().HasMaxLength(200);
            entity.Property(e => e.City).IsRequired().HasMaxLength(50);
            entity.Property(e => e.District).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Province).IsRequired().HasMaxLength(50);
            entity.Property(e => e.PostalCode).IsRequired().HasMaxLength(10);
            entity.HasOne(e => e.User)
                  .WithMany(e => e.Addresses)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Vendor configuration
        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BusinessName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.BusinessRegistrationNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.BusinessDescription).HasMaxLength(500);
            entity.Property(e => e.BusinessAddress).IsRequired().HasMaxLength(200);
            entity.Property(e => e.BusinessPhone).IsRequired().HasMaxLength(20);
            entity.Property(e => e.BusinessEmail).IsRequired().HasMaxLength(100);
            entity.HasOne(e => e.User)
                  .WithOne(e => e.Vendor)
                  .HasForeignKey<Vendor>(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Product configuration
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Unit).IsRequired().HasMaxLength(20);
            entity.Property(e => e.Category).IsRequired().HasMaxLength(50);
            entity.HasOne(e => e.Vendor)
                  .WithMany(e => e.Products)
                  .HasForeignKey(e => e.VendorId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // Order configuration
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(18,2)");
            entity.Property(e => e.DeliveryFee).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TaxAmount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            entity.HasIndex(e => e.OrderNumber).IsUnique();
            entity.HasOne(e => e.Customer)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Vendor)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.VendorId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.DeliveryPartner)
                  .WithMany(e => e.Orders)
                  .HasForeignKey(e => e.DeliveryPartnerId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        // OrderItem configuration
        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
            entity.HasOne(e => e.Order)
                  .WithMany(e => e.OrderItems)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Product)
                  .WithMany(e => e.OrderItems)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // DeliveryPartner configuration
        modelBuilder.Entity<DeliveryPartner>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.LicenseNumber).IsRequired().HasMaxLength(50);
            entity.Property(e => e.VehicleType).IsRequired().HasMaxLength(20);
            entity.Property(e => e.VehicleNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.TotalEarnings).HasColumnType("decimal(18,2)");
            entity.HasOne(e => e.User)
                  .WithOne(e => e.DeliveryPartner)
                  .HasForeignKey<DeliveryPartner>(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // OrderTracking configuration
        modelBuilder.Entity<OrderTracking>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Order)
                  .WithMany(e => e.TrackingHistory)
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        // ProductReview configuration
        modelBuilder.Entity<ProductReview>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.HasOne(e => e.Product)
                  .WithMany(e => e.Reviews)
                  .HasForeignKey(e => e.ProductId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Customer)
                  .WithMany()
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Order)
                  .WithMany()
                  .HasForeignKey(e => e.OrderId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
