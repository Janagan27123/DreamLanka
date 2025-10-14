using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetUserByIdQuery : IRequest<UserDto?>
{
    public int Id { get; set; }
}