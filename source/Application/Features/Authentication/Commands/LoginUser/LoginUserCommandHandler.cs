using Project.Application.Common.Interfaces;
using Project.Application.Common.Localizers;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Interfaces.Services;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandHandler(IUserRepository userRepository, ITokenService tokenService, IMediator mediator, CultureLocalizer localizer) : IRequestHandler<LoginUserCommand, LoginUserCommandResponse?>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IMediator _mediator = mediator;
    private readonly CultureLocalizer _localizer = localizer;

    public async Task<LoginUserCommandResponse?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        request.Request.Login = request.Request.Login.ToLowerInvariant();
        var user = _userRepository.Get(x => x.Username == request.Request.Login || x.Email == request.Request.Login);
        if (user == null || !user.VerifyPassword(request.Request.Password))
        {
            await _mediator.Publish(new DomainNotification("LoginUser", _localizer.Text("LoginInvalidCredentials")), cancellationToken);
            return default;
        }

        var token = _tokenService.GenerateToken(user);
        await _mediator.Publish(new DomainSuccessNotification("LoginUser", _localizer.Text("Success")), cancellationToken);
        return new LoginUserCommandResponse { 
            Token = token,
            Username = user.Username,
            Email = user.Email,
            Id = user.Id
        };
    }
}
