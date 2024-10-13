using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.ConfirmUser;

public class ConfirmUserCommand : Command<ConfirmUserCommandResponse>
{
    public string Token { get; set; }

    public ConfirmUserCommand(string token)
    {
        Token = token;
    }
}
