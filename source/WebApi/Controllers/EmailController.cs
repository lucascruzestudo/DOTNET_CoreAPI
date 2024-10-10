using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Email.Commands.EmailTest;

namespace Project.WebApi.Controllers;

public class EmailController : BaseController
{
    private readonly IMediator _mediatorHandler;

    public EmailController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IMediator mediatorHandler) : base(notifications, successNotifications, mediatorHandler)
    {
        _mediatorHandler = mediatorHandler;
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("Test")]
    [ProducesResponseType(typeof(EmailTestCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> EmailTest([FromBody] EmailTestCommandRequest request)
    {
        return Response(await _mediatorHandler.Send(new EmailTestCommand(request)));
    }
}
