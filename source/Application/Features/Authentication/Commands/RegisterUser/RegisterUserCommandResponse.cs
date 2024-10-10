namespace Project.Application.Features.Commands.RegisterUser;

public record RegisterUserCommandResponse
{
    public required Guid Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
}