using DreamLanka.Domain.Common;

namespace DreamLanka.Domain.Entities;

public class ProductReview : BaseEntity
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public int Rating { get; set; } // 1-5 stars
    public string? Comment { get; set; }
    public bool IsVerified { get; set; } = false;

    // Navigation properties
    public virtual Product Product { get; set; } = null!;
    public virtual User Customer { get; set; } = null!;
    public virtual Order Order { get; set; } = null!;
}
