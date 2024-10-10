namespace Project.Application.Common.Interfaces;

public interface IUser
{
    string? Id { get; }
    string? Role { get; }
    string? Username { get; }
    string? Email { get; }
}
