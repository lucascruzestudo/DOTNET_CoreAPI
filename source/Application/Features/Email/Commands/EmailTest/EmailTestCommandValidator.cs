namespace Project.Application.Features.Email.Commands.EmailTest;

public class EmailTestCommandValidator : AbstractValidator<EmailTestCommand>
{
    public EmailTestCommandValidator()
    {
        RuleFor(x => x.Request.ToAddress)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .EmailAddress().WithMessage("{PropertyName} is invalid.");
    }
}
