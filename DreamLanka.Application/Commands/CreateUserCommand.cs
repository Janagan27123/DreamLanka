using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Commands;

public class CreateUserCommand : IRequest<UserDto>
{
    public CreateUserDto CreateUserDto { get; set; } = null!;
}