using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Domain.Common;
using Project.Domain.Notifications;
using System.Globalization;

namespace Project.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly DomainSuccessNotificationHandler _successNotifications;
        private readonly IMediator _mediatorHandler;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected Guid ClienteId;

        protected BaseController(
            INotificationHandler<DomainNotification> notifications,
            INotificationHandler<DomainSuccessNotification> successNotifications,
            IMediator mediatorHandler,
            IHttpContextAccessor httpContextAccessor)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _successNotifications = (DomainSuccessNotificationHandler)successNotifications;
            _mediatorHandler = mediatorHandler;
            _httpContextAccessor = httpContextAccessor;

            SetCultureFromHeader();
        }

        private void SetCultureFromHeader()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null &&
                httpContext.Request.Headers.TryGetValue("Accept-Language", out Microsoft.Extensions.Primitives.StringValues value))
            {
                var cultureHeader = value.ToString();
                var acceptedCultures = new[] { "en-US", "pt-BR", "es-ES" };

                var cultures = cultureHeader.Split(',')
                    .Select(c => c.Trim())
                    .Where(c => acceptedCultures.Contains(c));

                var cultureInfo = cultures.FirstOrDefault() != null
                    ? new CultureInfo(cultures.First())
                    : new CultureInfo("en-US");

                CultureInfo.CurrentCulture = cultureInfo;
                CultureInfo.CurrentUICulture = cultureInfo;
            }
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
}
