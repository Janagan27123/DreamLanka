using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class Order : BaseEntity
{
    public int CustomerId { get; set; }
    public int VendorId { get; set; }
    public int? DeliveryPartnerId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal SubTotal { get; set; }
    public decimal DeliveryFee { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    public DateTime? ConfirmedAt { get; set; }
    public DateTime? PreparedAt { get; set; }
    public DateTime? PickedUpAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public string? DeliveryNotes { get; set; }
    public string? CustomerNotes { get; set; }

    // Navigation properties
    public virtual User Customer { get; set; } = null!;
    public virtual Vendor Vendor { get; set; } = null!;
    public virtual DeliveryPartner? DeliveryPartner { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<OrderTracking> TrackingHistory { get; set; } = new List<OrderTracking>();
}