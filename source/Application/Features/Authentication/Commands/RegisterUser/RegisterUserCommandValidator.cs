using Microsoft.Extensions.Localization;
using Project.Application.Common.Localizers;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Application.Features.Commands.RegisterUser
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly CultureLocalizer _localizer;
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandValidator(CultureLocalizer localizer, IUserRepository userRepository)
        {
            _localizer = localizer;
            _userRepository = userRepository;

            RuleFor(x => x.Request)
                .NotNull().WithMessage(_localizer.Text("RequiredField", "Request"))
                .DependentRules(() =>
                {
                    RuleFor(x => x.Request.Username)
                        .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Username"))
                        .Must(x => !x.Contains(' ')).WithMessage(_localizer.Text("UsernameCannotContainSpaces"))
                        .Must(x =>
                        {
                            var existingUser = _userRepository.Get(user => user.Username == x);
                            return existingUser == null;
                        }).WithMessage(_localizer.Text("RegisterUsernameExists"));

                    RuleFor(x => x.Request.Email)
                        .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Email"))
                        .EmailAddress().WithMessage(_localizer.Text("InvalidEmail", "Email"))
                        .Must(x =>
                        {
                            var existingUser = _userRepository.Get(user => user.Email == x);
                            return existingUser == null;
                        }).WithMessage(_localizer.Text("RegisterEmailExists"));
                });
        }
    }
}
