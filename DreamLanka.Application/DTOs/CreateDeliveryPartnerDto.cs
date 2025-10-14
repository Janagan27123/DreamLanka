namespace DreamLanka.Application.DTOs;

public class CreateDeliveryPartnerDto
{
    public int UserId { get; set; }
    public string LicenseNumber { get; set; } = string.Empty;
    public string VehicleType { get; set; } = string.Empty;
    public string VehicleNumber { get; set; } = string.Empty;
}