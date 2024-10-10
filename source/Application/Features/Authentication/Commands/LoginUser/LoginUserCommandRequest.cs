namespace Project.Application.Features.Commands.LoginUser
{
    public record LoginUserCommandRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}