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

        // Create new user
        var user = new User
        {
            FirstName = request.CreateUserDto.FirstName,
            LastName = request.CreateUserDto.LastName,
            Email = request.CreateUserDto.Email,
            PhoneNumber = request.CreateUserDto.PhoneNumber,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.CreateUserDto.Password),
            UserType = request.CreateUserDto.UserType,
            PreferredLanguage = request.CreateUserDto.PreferredLanguage,
            IsVerified = false
        };

        var createdUser = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(createdUser);
    }
}