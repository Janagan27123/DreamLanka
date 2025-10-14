using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Commands;

public class UpdateUserCommand : IRequest<UserDto>
{
    public int Id { get; set; }
    public CreateUserDto UpdateUserDto { get; set; } = null!;
}