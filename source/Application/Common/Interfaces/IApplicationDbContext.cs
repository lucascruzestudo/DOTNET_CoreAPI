using Project.Domain.Entities;

namespace Project.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Role> User { get; set; }
    public DbSet<Role> Role { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
