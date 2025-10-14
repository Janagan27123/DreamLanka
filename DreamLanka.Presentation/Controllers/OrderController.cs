using DreamLanka.Application.Commands;
using DreamLanka.Application.DTOs;
using DreamLanka.Application.Queries;
using DreamLanka.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamLanka.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<OrderDto>> CreateOrder([FromBody] CreateOrderRequest request)
    {
        try
        {
            var command = new CreateOrderCommand
            {
                CustomerId = request.CustomerId,
                VendorId = request.VendorId,
                OrderItems = request.OrderItems,
                CustomerNotes = request.CustomerNotes
            };
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDto>> GetOrderById(int id)
    {
        try
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound(new { message = "Order not found" });

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}/status")]
    public async Task<ActionResult<bool>> UpdateOrderStatus(int id, [FromBody] UpdateOrderStatusRequest request)
    {
        try
        {
            var command = new UpdateOrderStatusCommand { OrderId = id, Status = request.Status, Notes = request.Notes };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

// Request DTOs for Order Controller
public class CreateOrderRequest
{
    public int CustomerId { get; set; }
    public int VendorId { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = [];
    public string? CustomerNotes { get; set; }
}

public class UpdateOrderStatusRequest
{
    public OrderStatus Status { get; set; }
    public string? Notes { get; set; }
}
