﻿using Microsoft.AspNetCore.Mvc;
using Project.Domain.Common;
using Project.Domain.Notifications;

namespace Project.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : Controller
{
    private readonly DomainNotificationHandler _notifications;
    private readonly DomainSuccessNotificationHandler _successNotifications;
    private readonly IMediator _mediatorHandler;

    protected Guid ClienteId;

    protected BaseController(INotificationHandler<DomainNotification> notifications,
                             INotificationHandler<DomainSuccessNotification> successNotifications,
                             IMediator mediatorHandler)
    {
        _notifications = (DomainNotificationHandler)notifications;
        _successNotifications = (DomainSuccessNotificationHandler)successNotifications;
        _mediatorHandler = mediatorHandler;
    }

    protected bool IsOperationValid()
    {
        return !_notifications.HasNotification();
    }

    protected IEnumerable<string> GetErrorMessages()
    {
        return _notifications.GetNotifications().Select(c => c.Value).ToList();
    }
    
    protected IEnumerable<string> GetSuccessMessages()
    {
        return _successNotifications.GetNotifications().Select(c => c.Value).ToList();
    }

    protected void NotifyError(string code, string message)
    {
        _mediatorHandler.Publish(new DomainNotification(code, message));
    }

    protected new IActionResult Response(object? result = null)
    {
        if (IsOperationValid())
            return Ok(ResponseBase<object?>.Success(result, GetSuccessMessages()));

        return BadRequest(ResponseBase<object>.Failure(GetErrorMessages()));
    }
}
