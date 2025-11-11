using AutoMapper;
using DreamLanka.Application.DTOs;
using DreamLanka.Domain.Entities;
using DreamLanka.Domain.Interfaces;
using MediatR;

namespace DreamLanka.Application.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Check if user already exists
        var existingUser = await _userRepository.GetByEmailAsync(request.CreateUserDto.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User with this email already exists");
        }

        // Use AutoMapper instead of manual mapping
        var user = _mapper.Map<Domain.Entities.User>(request.CreateUserDto);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.CreateUserDto.Password);
        user.IsVerified = false;

        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }
}