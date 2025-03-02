using Project.Application.Common.Localizers;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Interfaces.Services;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IUserRepository userRepository, IMediator mediator, CultureLocalizer localizer, IRedisService redisService, IEmailService emailService) : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse?>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMediator _mediator = mediator;
        private readonly CultureLocalizer _localizer = localizer;
        private readonly IRedisService _redisService = redisService;
        private readonly IEmailService _emailService = emailService;

        public async Task<RegisterUserCommandResponse?> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var expirationMinutes = 15;
            var token = Guid.NewGuid().ToString();
            var tokenInfo = $"{command.Request.Email};{User.HashPassword(command.Request.Password)};{command.Request.Username}";
            await _redisService.SetAsync(token, tokenInfo, TimeSpan.FromMinutes(expirationMinutes));

            var confirmationUrl = $"http://localhost:5000/api/v1/Authentication/Confirm/{token}";

            var subject = _localizer.Text("ConfirmEmailSubject");
            var bodyContent = _localizer.Text("ConfirmEmailBody", command.Request.Username, confirmationUrl, expirationMinutes);

            await _emailService.SendEmailAsync(command.Request.Email, subject, bodyContent);

            await _mediator.Publish(new DomainSuccessNotification("RegisterUser", _localizer.Text("Success")), cancellationToken);

            return new RegisterUserCommandResponse { Username = command.Request.Username, Email = command.Request.Email };
        }
    }
}
