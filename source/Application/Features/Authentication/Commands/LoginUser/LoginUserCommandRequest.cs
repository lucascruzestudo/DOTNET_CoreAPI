namespace Project.Application.Features.Commands.LoginUser
{
    public record LoginUserCommandRequest
    {
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}