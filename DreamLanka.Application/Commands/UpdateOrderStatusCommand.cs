using DreamLanka.Domain.Common;
using MediatR;

namespace DreamLanka.Application.Commands;

public class UpdateOrderStatusCommand : IRequest<bool>
{
    public int OrderId { get; set; }
    public OrderStatus Status { get; set; }
    public string? Notes { get; set; }
}
