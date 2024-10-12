using Microsoft.AspNetCore.Mvc;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Project.Application.Features.Email.Commands.EmailTest;

namespace Project.WebApi.Controllers;

public class EmailController(INotificationHandler<DomainNotification> notifications,
                      INotificationHandler<DomainSuccessNotification> successNotifications,
                      IHttpContextAccessor httpContextAccessor,
                      IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler, httpContextAccessor)
{
    private readonly IMediator _mediatorHandler = mediatorHandler;

    [Authorize(Roles = "Admin, User")]
    [HttpPost("Test")]
    [ProducesResponseType(typeof(EmailTestCommandResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> EmailTest()
    {
        return Response(await _mediatorHandler.Send(new EmailTestCommand()));
    }
}
