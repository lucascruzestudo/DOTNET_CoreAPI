using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommand : Command<LoginUserCommandResponse>
{
    public LoginUserCommandRequest Request { get; set; }
    public LoginUserCommand(LoginUserCommandRequest request)
    {
        Request = request;
    }
}
