using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IBookRepository : IAsyncRepository<Book>
{
    Task<bool> ExistsAsync(Guid bookId);
}
