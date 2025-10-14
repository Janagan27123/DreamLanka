using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class DeliveryPartner : BaseEntity
{
    public int UserId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty; // Bike, Car, Van
    public string VehicleNumber { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public bool IsApproved { get; set; } = false;
    public DateTime? ApprovedAt { get; set; }
    public int? ApprovedBy { get; set; }
    public string? RejectionReason { get; set; }
    public double Rating { get; set; } = 0.0;
    public int TotalDeliveries { get; set; } = 0;
    public decimal TotalEarnings { get; set; } = 0;

    // Navigation properties
    public virtual User User { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}