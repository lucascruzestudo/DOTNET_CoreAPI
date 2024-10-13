namespace Project.Application.Features.Commands.ConfirmUser;

public record ConfirmUserCommandResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}