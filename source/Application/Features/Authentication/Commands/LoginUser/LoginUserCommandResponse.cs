namespace Project.Application.Features.Commands.LoginUser
{
    public record LoginUserCommandResponse
    {
        public required string Token { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required Guid Id { get; set; }
    }
}
