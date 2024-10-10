namespace Project.Application.Features.Commands.LoginUser;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull().WithMessage("{PropertyName} is required.");

        RuleFor(x => x.Request.Login)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(x => x.Request != null)
            .NotNull().WithMessage("{PropertyName} is required.")
            .When(x => x.Request != null);

        RuleFor(x => x.Request.Password)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .When(x => x.Request != null)
            .NotNull().WithMessage("{PropertyName} is required.")
            .When(x => x.Request != null);

    }
}
