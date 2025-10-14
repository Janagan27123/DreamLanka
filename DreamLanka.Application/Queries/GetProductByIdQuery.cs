using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetProductByIdQuery : IRequest<ProductDto?>
{
    public int Id { get; set; }
}