using System.Linq.Expressions;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IReadOnlyList<T>> ListAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteByIdAsync(Guid id);
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> Query();  
}
