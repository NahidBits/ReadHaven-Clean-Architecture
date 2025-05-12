using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IBookRepository : IAsyncRepository<Book>
{
   // Task<List<Book>> GetCategoriesWithEvents(bool includePassedEvents);
}
