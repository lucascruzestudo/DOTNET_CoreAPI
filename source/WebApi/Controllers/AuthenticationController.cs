using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.Commands.RegisterUser;
using Project.Application.Features.Commands.LoginUser;
using Project.Domain.Notifications;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Project.WebApi.Controllers
{
    public class AuthenticationController(INotificationHandler<DomainNotification> notifications,
                          INotificationHandler<DomainSuccessNotification> successNotifications,
                          IHttpContextAccessor httpContextAccessor,
                          IMediator mediatorHandler) : BaseController(notifications, successNotifications, mediatorHandler, httpContextAccessor)
    {
        private readonly IMediator _mediatorHandler = mediatorHandler;

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        [SwaggerOperation(Summary = "Register a new user.")]
        [ProducesResponseType(typeof(RegisterUserCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new RegisterUserCommand(request)));
        }

        [HttpPost("Login")]
        [SwaggerOperation(Summary = "Authenticate a user.")]
        [ProducesResponseType(typeof(LoginUserCommandResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest request)
        {
            return Response(await _mediatorHandler.Send(new LoginUserCommand(request)));
        }
    }
}
