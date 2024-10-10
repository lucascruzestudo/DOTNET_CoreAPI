using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.RegisterUser;

public class RegisterUserCommand : Command<RegisterUserCommandResponse>
{
    public RegisterUserCommandRequest Request { get; set; }
    public RegisterUserCommand(RegisterUserCommandRequest request)
    {
        Request = request;
    }
}
