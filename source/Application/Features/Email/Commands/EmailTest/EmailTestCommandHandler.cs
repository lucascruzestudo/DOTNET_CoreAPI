using Project.Application.Common.Interfaces;
using Project.Application.Common.Localizers;
using Project.Domain.Interfaces.Services;
using Project.Domain.Notifications;

namespace Project.Application.Features.Email.Commands.EmailTest;

public class EmailTestCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IEmailService emailService, IUser user, CultureLocalizer localizer) : IRequestHandler<EmailTestCommand, EmailTestCommandResponse?>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMediator _mediator = mediator;
    private readonly IEmailService _emailService = emailService;
    private readonly IUser _user = user;
    private readonly CultureLocalizer _localizer = localizer;

    public async Task<EmailTestCommandResponse?> Handle(EmailTestCommand command, CancellationToken cancellationToken)
    {

        if (_user.Email == null) {
            await _mediator.Publish(new DomainSuccessNotification("EmailTest", _localizer.Text("FieldNotFound", "Email")), cancellationToken);
            return default;
        }

        string subject = "Email Service Test";
        string bodyContent = @"
        <h1>Test Email Confirmation</h1>
        <br>
        <p>Dear Programmer,</p>
        <p>This is a test email to confirm that our email delivery system is functioning properly.</p>
        <p>Here are the details of your test:</p>
        <ul>
            <li>Subject: " + subject + @"</li>
            <li>To: " + _user.Email + @"</li>
            <li>Timestamp: " + DateTime.Now + @"</li>
        </ul>
        ";

        await _emailService.SendEmailAsync(_user.Email, subject, bodyContent);

        _unitOfWork.Commit();
        await _mediator.Publish(new DomainSuccessNotification("EmailTest", _localizer.Text("Success")), cancellationToken);
        var response = new EmailTestCommandResponse { };
        return response;
    }
}