using Project.Application.Common.Interfaces;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories;
public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private readonly Dictionary<Type, object> _repositories = [];

    public IRepositoryBase<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepositoryBase<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new RepositoryBase<TEntity>(_dbContext);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public int Commit()
    {
        return _dbContext.SaveChanges();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}
