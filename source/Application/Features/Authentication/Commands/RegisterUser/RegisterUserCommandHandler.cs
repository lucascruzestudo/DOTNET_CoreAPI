using Project.Application.Common.Interfaces;
using Project.Application.Common.Localizers;
using Project.Domain.Constants;
using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;
using Project.Domain.Notifications;

namespace Project.Application.Features.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMediator mediator, CultureLocalizer localizer) : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse?>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMediator _mediator = mediator;
        private readonly CultureLocalizer _localizer = localizer;

        public async Task<RegisterUserCommandResponse?> Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {

            var existingUser = _userRepository.Get(x => x.Username == command.Request.Username || x.Email == command.Request.Email);
            if (existingUser is not null)
            {
                if (existingUser.Username == command.Request.Username)
                {
                    await _mediator.Publish(new DomainNotification("RegisterUser", _localizer.Text("RegisterUsernameExists")), cancellationToken);
                }
                else
                {
                    await _mediator.Publish(new DomainNotification("RegisterUser", _localizer.Text("RegisterEmailExists")), cancellationToken);
                }

                return default;
            }

            var user = new User(
                username: command.Request.Username,
                password: command.Request.Password,
                email: command.Request.Email,
                roleId: RoleConstants.User
            );

            user = _userRepository.Add(user);
            _unitOfWork.Commit();

            await _mediator.Publish(new DomainSuccessNotification("RegisterUser", _localizer.Text("Success")), cancellationToken);

            return new RegisterUserCommandResponse { Id = user.Id, Username = user.Username, Email = user.Email };
        }
    }
}
