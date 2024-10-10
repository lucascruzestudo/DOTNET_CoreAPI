using Project.Domain.Entities;

namespace Project.Domain.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
