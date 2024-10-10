using Project.Domain.Notifications;

namespace Project.Application.Features.Email.Commands.EmailTest;

public class EmailTestCommand(EmailTestCommandRequest request) : Command<EmailTestCommandResponse>
{
    public EmailTestCommandRequest Request { get; set; } = request;
}
