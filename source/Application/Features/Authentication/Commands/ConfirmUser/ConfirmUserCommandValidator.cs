using Project.Application.Common.Localizers;

namespace Project.Application.Features.Commands.ConfirmUser;

public class ConfirmUserCommandValidator : AbstractValidator<ConfirmUserCommand>
{

    private readonly CultureLocalizer _localizer;

    public ConfirmUserCommandValidator(CultureLocalizer localizer)
    {
        _localizer = localizer;

        RuleFor(x => x.Token)
            .NotNull().WithMessage(_localizer.Text("RequiredField", "Token"));
    }
}
