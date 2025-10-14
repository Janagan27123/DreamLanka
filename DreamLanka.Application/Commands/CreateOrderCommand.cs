using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Commands;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public int CustomerId { get; set; }
    public int VendorId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = [];
    public string? CustomerNotes { get; set; }
}
