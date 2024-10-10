using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class UserRepository(ApplicationDbContext dbContext) : RepositoryBase<User>(dbContext), IUserRepository
    {
    }
}
