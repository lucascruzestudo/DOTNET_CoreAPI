using Project.Application.Common.Messages;

namespace Project.Application.Features.Commands.RegisterUser;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Request)
            .NotNull().WithMessage(ErrorMessages.InvalidRequest)
            .DependentRules(() =>
            {
                RuleFor(x => x.Request.Username)
                    .NotEmpty().WithMessage(ErrorMessages.RequiredProperty)
                    .NotNull().WithMessage(ErrorMessages.RequiredProperty)
                    .Must(x => !x.Contains(' ')).WithMessage(ErrorMessages.InvalidProperty);

                RuleFor(x => x.Request.Password)
                    .NotEmpty().WithMessage(ErrorMessages.RequiredProperty)
                    .NotNull().WithMessage(ErrorMessages.RequiredProperty)
                    .MinimumLength(8).WithMessage(ErrorMessages.PasswordTooShort)
                    .Matches(@"[A-Z]").WithMessage(ErrorMessages.PasswordMissingUppercase)
                    .Matches(@"[a-z]").WithMessage(ErrorMessages.PasswordMissingLowercase)
                    .Matches(@"[0-9]").WithMessage(ErrorMessages.PasswordMissingNumber)
                    .Matches(@"[^a-zA-Z0-9]").WithMessage(ErrorMessages.PasswordMissingSpecialCharacter);

                RuleFor(x => x.Request.Email)
                    .NotEmpty().WithMessage(ErrorMessages.RequiredProperty)
                    .NotNull().WithMessage(ErrorMessages.RequiredProperty)
                    .EmailAddress().WithMessage(ErrorMessages.InvalidProperty);
        });
    }
}
