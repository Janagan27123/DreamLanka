using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetOrderByIdQuery : IRequest<OrderDto?>
{
    public int Id { get; set; }
}