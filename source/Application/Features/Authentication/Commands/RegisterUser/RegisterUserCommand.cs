using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.RegisterUser;

public class RegisterUserCommand(RegisterUserCommandRequest request) : Command<RegisterUserCommandResponse>
{
    public RegisterUserCommandRequest Request { get; set; } = request;
}
