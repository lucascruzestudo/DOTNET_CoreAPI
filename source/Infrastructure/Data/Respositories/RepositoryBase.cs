using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Interfaces.Data.Repositories;

namespace Project.Infrastructure.Data.Respositories;
public class RepositoryBase<T> : IRepositoryBase<T>, IDisposable where T : class
{
    private readonly ApplicationDbContext _dbContext;
    public RepositoryBase(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public virtual IEnumerable<T> GetAll() => _dbContext.Set<T>().ToArray();

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        _dbContext.ChangeTracker.Clear();
        return _dbContext.Set<T>().Where(predicate).AsQueryable().FirstOrDefault();
    }

    public IEnumerable<T> GetRanged(Expression<Func<T, bool>> predicate)
    {
        _dbContext.ChangeTracker.Clear();
        return _dbContext.Set<T>().Where(predicate).AsQueryable().ToList();
    }

    public T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        return entity;
    }
    public T Update(T entity)
    {
        _dbContext.ChangeTracker.Clear();
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.Set<T>().Update(entity);
        return entity;
    }

    public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
    {
        _dbContext.ChangeTracker.Clear();

        foreach (var entity in entities)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
        }

        _dbContext.SaveChanges();

        return entities;
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }

    public void DeleteRange(T[] entityArray)
    {
        _dbContext.Set<T>().RemoveRange(entityArray);
    }

    public void Dispose() => _dbContext.DisposeAsync();

    public IQueryable<T> GetAll(params string[] including)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        if (including != null)
            including.ToList().ForEach(include =>
            {
                if (!string.IsNullOrEmpty(include))
                    query = query.Include(include);
            });
        return query;
    }

    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] including)
    {
        var query = _dbContext.Set<T>().AsQueryable();
        if (including != null)
            including.ToList().ForEach(include =>
            {
                if (include != null)
                    query = query.Include(include);
            });
        return query;
    }

    public IEnumerable<T> GetWithIncludes(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] including)
    {
        _dbContext.ChangeTracker.Clear();

        var query = _dbContext.Set<T>().AsQueryable().AsNoTracking();
        if (including != null)
        {
            including.ToList().ForEach(include =>
            {
                if (include != null)
                    query = query.Where(predicate).Include(include);
            });
            return query.ToList();
        }
        return query.Where(predicate).ToList();
    }
}
