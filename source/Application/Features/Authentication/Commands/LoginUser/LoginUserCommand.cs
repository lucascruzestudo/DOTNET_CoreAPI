using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommand(LoginUserCommandRequest request) : Command<LoginUserCommandResponse>
{
    public LoginUserCommandRequest Request { get; set; } = request;
}
