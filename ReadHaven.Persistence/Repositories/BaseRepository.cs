using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReadHaven.Application.Contracts.Persistence;

namespace ReadHaven.Persistence.Repositories;

public class BaseRepository<T> : IAsyncRepository<T> where T : class
{
    protected readonly ReadHavenDbContext _dbContext;

    public BaseRepository(ReadHavenDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        T? entity = await _dbContext.Set<T>().FindAsync(id);
        return entity;
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size)
    {
        return await _dbContext.Set<T>()
                               .Skip((page - 1) * size)
                               .Take(size)
                               .AsNoTracking()
                               .ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbContext.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity); 
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteRangeAsync(IEnumerable<T> entities)
    {
        foreach (var entity in entities)
        {
            _dbContext.Set<T>().Remove(entity); 
        }

        await _dbContext.SaveChangesAsync();
    }
}
