using AutoMapper;
using DreamLanka.Application.DTOs;
using DreamLanka.Domain.Entities;
using DreamLanka.Domain.Interfaces;
using MediatR;

namespace DreamLanka.Application.Commands;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            throw new InvalidOperationException("User not found");
        }

        // Update user properties
        user.FirstName = request.UpdateUserDto.FirstName;
        user.LastName = request.UpdateUserDto.LastName;
        user.Email = request.UpdateUserDto.Email;
        user.PhoneNumber = request.UpdateUserDto.PhoneNumber;
        user.PreferredLanguage = request.UpdateUserDto.PreferredLanguage;
        user.UpdatedAt = DateTime.UtcNow;

        // Update password if provided
        if (!string.IsNullOrEmpty(request.UpdateUserDto.Password))
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.UpdateUserDto.Password);
        }

        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDto>(user);
    }
}
