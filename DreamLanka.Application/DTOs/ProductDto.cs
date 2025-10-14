namespace DreamLanka.Application.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public int VendorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public double Rating { get; set; }
    public int TotalReviews { get; set; }
    public decimal? DiscountPercentage { get; set; }
    public DateTime? DiscountValidUntil { get; set; }
    public DateTime CreatedAt { get; set; }
}