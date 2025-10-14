using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetUserByEmailQuery : IRequest<UserDto?>
{
    public string Email { get; set; } = string.Empty;
}