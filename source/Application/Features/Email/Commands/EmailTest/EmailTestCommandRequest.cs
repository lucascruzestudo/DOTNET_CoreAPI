namespace Project.Application.Features.Email.Commands.EmailTest;

public record EmailTestCommandRequest
{
    public string ToAddress { get; set; } = string.Empty;
}