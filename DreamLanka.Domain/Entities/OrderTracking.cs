using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class OrderTracking : BaseEntity
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public string? Notes { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    // Navigation properties
    public virtual Order Order { get; set; } = null!;
}