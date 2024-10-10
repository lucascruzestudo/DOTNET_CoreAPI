namespace Project.Application.Features.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull().WithMessage("{PropertyName} is required.")
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.Username)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is required.")
                    .Must(x => !x.Contains(' ')).WithMessage("{PropertyName} cannot contain spaces.");

                RuleFor(x => x.Request.Password)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is required.")
                    .MinimumLength(8).WithMessage("{PropertyName} must be at least 8 characters long.")
                    .Matches(@"[A-Z]").WithMessage("{PropertyName} must contain at least one uppercase character.")
                    .Matches(@"[a-z]").WithMessage("{PropertyName} must contain at least one lowercase character.")
                    .Matches(@"[0-9]").WithMessage("{PropertyName} must contain at least one number.")
                    .Matches(@"[^a-zA-Z0-9]").WithMessage("{PropertyName} must contain at least one special character.");

                RuleFor(x => x.Request.Email)
                    .NotEmpty().WithMessage("{PropertyName} is required.")
                    .NotNull().WithMessage("{PropertyName} is required.")
                    .EmailAddress().WithMessage("{PropertyName} is invalid.");
        });
    }
}
