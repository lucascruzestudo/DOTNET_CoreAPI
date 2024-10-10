using Project.Application.Common.Messages;

namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull().WithMessage(ErrorMessages.InvalidRequest)
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.Login)
                    .NotEmpty().WithMessage(ErrorMessages.RequiredProperty)
                    .NotNull().WithMessage(ErrorMessages.RequiredProperty);

                RuleFor(x => x.Request.Password)
                    .NotEmpty().WithMessage(ErrorMessages.RequiredProperty)
                    .NotNull().WithMessage(ErrorMessages.RequiredProperty);
            });
    }
}