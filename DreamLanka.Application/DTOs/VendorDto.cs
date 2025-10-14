using DreamLanka.Domain.Common;

namespace DreamLanka.Application.DTOs;

public class VendorDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string BusinessRegistrationNumber { get; set; } = string.Empty;
    public string BusinessDescription { get; set; } = string.Empty;
    public string BusinessAddress { get; set; } = string.Empty;
    public string BusinessPhone { get; set; } = string.Empty;
    public string BusinessEmail { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public int? ApprovedBy { get; set; }
    public string? RejectionReason { get; set; }
    public double Rating { get; set; }
    public int TotalReviews { get; set; }
    public DateTime CreatedAt { get; set; }
}
