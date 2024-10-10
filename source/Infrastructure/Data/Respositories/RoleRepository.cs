using Project.Domain.Entities;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories
{
    public class RoleRepository(ApplicationDbContext dbContext) : RepositoryBase<Role>(dbContext), IRoleRepository
    {
    }
}
