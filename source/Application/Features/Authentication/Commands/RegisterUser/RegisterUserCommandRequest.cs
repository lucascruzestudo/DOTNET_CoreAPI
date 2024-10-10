namespace Project.Application.Features.Commands.RegisterUser;

public record RegisterUserCommandRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
}