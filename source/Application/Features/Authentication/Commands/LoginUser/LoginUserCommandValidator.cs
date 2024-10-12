using Microsoft.Extensions.Localization;
using Project.Application.Common.Localizers;
using Project.Application.Common.Messages;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    private readonly CultureLocalizer _localizer;

    public LoginUserCommandValidator(CultureLocalizer localizer)
    {
        _localizer = localizer;

        RuleFor(x => x.Request)
            .NotNull().WithMessage(ErrorMessages.InvalidRequest)
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.Login)
                    .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Login"))
                    .NotNull().WithMessage(_localizer.Text("RequiredField", "Login"));

                RuleFor(x => x.Request.Password)
                    .NotEmpty().WithMessage(_localizer.Text("RequiredField", "Password"))
                    .NotNull().WithMessage(_localizer.Text("RequiredField", "Password"));
            });
    }
}
