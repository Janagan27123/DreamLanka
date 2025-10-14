using DreamLanka.Domain.Common;
using System.Net;
using System.Numerics;

namespace DreamLanka.Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public UserType UserType { get; set; }
    public bool IsVerified { get; set; } = false;
    public Language PreferredLanguage { get; set; } = Language.English;
    public string? ProfileImageUrl { get; set; }

    // Navigation properties
    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual Vendor? Vendor { get; set; }
    public virtual DeliveryPartner? DeliveryPartner { get; set; }
}
