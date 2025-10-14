using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class Product : BaseEntity
{
    public int VendorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Unit { get; set; } = string.Empty; // kg, piece, dozen, etc.
    public string Category { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; } = true;
    public double Rating { get; set; } = 0.0;
    public int TotalReviews { get; set; } = 0;
    public decimal? DiscountPercentage { get; set; }
    public DateTime? DiscountValidUntil { get; set; }

    // Navigation properties
    public virtual Vendor Vendor { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();
}