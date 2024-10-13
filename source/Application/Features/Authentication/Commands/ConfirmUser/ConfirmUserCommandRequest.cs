namespace Project.Application.Features.Commands.ConfirmUser;

public record ConfirmUserCommandRequest
{
    public string Token { get; set; } = string.Empty;
}