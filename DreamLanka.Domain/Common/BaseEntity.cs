using System.ComponentModel.DataAnnotations;

namespace DreamLanka.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}

public enum UserType
{
    Customer = 1,
    Vendor = 2,
    DeliveryPartner = 3,
    Admin = 4
}

public enum OrderStatus
{
    Pending = 1,
    Confirmed = 2,
    Preparing = 3,
    ReadyForPickup = 4,
    OutForDelivery = 5,
    Delivered = 6,
    Cancelled = 7
}

public enum PaymentStatus
{
    Pending = 1,
    Paid = 2,
    Failed = 3,
    Refunded = 4
}

public enum PaymentMethod
{
    CashOnDelivery = 1,
    CreditCard = 2,
    DebitCard = 3,
    DigitalWallet = 4
}

public enum Language
{
    English = 1,
    Sinhala = 2,
    Tamil = 3
}