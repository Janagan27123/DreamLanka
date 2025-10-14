using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class Address : BaseEntity
{
    public int UserId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string District { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string? Landmark { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsDefault { get; set; } = false;

    // Navigation properties
    public virtual User User { get; set; } = null!;
}
