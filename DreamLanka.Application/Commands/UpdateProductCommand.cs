using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Commands;

public class UpdateProductCommand : IRequest<ProductDto>
{
    public int Id { get; set; }
    public CreateProductDto UpdateProductDto { get; set; } = null!;
}