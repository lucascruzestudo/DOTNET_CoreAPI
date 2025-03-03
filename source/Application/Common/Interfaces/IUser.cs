namespace Project.Application.Common.Interfaces;

public interface IUser
{
    Guid? Id { get; }
    string? Role { get; }
    string? Username { get; }
    string? Email { get; }
}
