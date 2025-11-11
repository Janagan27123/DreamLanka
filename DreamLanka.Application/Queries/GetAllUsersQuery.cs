using DreamLanka.Application.Common;
using DreamLanka.Application.DTOs;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetAllUsersQuery : IRequest<PagedResult<UserDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
