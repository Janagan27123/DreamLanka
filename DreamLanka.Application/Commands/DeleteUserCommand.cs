using MediatR;

namespace DreamLanka.Application.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }
}