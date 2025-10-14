using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Commands;

public class CreateProductCommand : IRequest<ProductDto>
{
    public int VendorId { get; set; }
    public CreateProductDto CreateProductDto { get; set; } = null!;
}
