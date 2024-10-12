using Microsoft.Extensions.Localization;
using Project.Application.Common.Localizers;

namespace Project.Application.Features.Commands.RegisterUser;
public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    private readonly CultureLocalizer _localizer;

    public RegisterUserCommandValidator(CultureLocalizer localizer)
    {
        _localizer = localizer;

        RuleFor(x => x.Request.Username)
            .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Username"))
            .Must(x => !x.Contains(' ')).WithMessage(_localizer.Text("UsernameCannotContainSpaces"));

        RuleFor(x => x.Request.Password)
            .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Password"))
            .MinimumLength(8).WithMessage(_localizer.Text("PasswordMinLength", 8))
            .Matches(@"[A-Z]").WithMessage(_localizer.Text("PasswordUppercase"))
            .Matches(@"[a-z]").WithMessage(_localizer.Text("PasswordLowercase"))
            .Matches(@"[0-9]").WithMessage(_localizer.Text("PasswordNumber"))
            .Matches(@"[^a-zA-Z0-9]").WithMessage(_localizer.Text("PasswordSpecialCharacter"));

        RuleFor(x => x.Request.Email)
            .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Email"))
            .EmailAddress().WithMessage(_localizer.Text("InvalidEmail", "Email"));
    }
}
