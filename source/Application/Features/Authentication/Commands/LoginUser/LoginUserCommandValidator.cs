namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Request.Username)
            .NotEmpty().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.");
    }
}
