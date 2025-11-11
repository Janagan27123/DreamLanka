using DreamLanka.Application.Commands;
using DreamLanka.Application.Common;
using DreamLanka.Application.DTOs;
using DreamLanka.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DreamLanka.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var command = new CreateUserCommand { CreateUserDto = createUserDto };
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUserById(int id)
    {
        var query = new GetUserByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound(new { message = "User not found" });

        return Ok(result);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
    {
        var query = new GetUserByEmailQuery { Email = email };
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound(new { message = "User not found" });

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<PagedResult<UserDto>>> GetAllUsers(
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 10)
    {
        var query = new GetAllUsersQuery { PageNumber = pageNumber, PageSize = pageSize };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] CreateUserDto updateUserDto)
    {
        var command = new UpdateUserCommand { Id = id, UpdateUserDto = updateUserDto };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        var command = new DeleteUserCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
