using AutoMapper;
using DreamLanka.Application.Common;
using DreamLanka.Application.DTOs;
using DreamLanka.Domain.Interfaces;
using MediatR;

namespace DreamLanka.Application.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, PagedResult<UserDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(
        IUserRepository userRepository, 
        IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<PagedResult<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var allUsers = await _userRepository.GetAllAsync();
        var usersList = allUsers.ToList();
        
        var totalCount = usersList.Count;
        var pagedUsers = usersList
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        return new PagedResult<UserDto>
        {
            Data = _mapper.Map<List<UserDto>>(pagedUsers),
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            TotalCount = totalCount
        };
    }
}
