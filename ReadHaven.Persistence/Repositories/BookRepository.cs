using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReadHaven.Persistence.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository(ReadHavenDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<List<Book>> GetBooksWithPriceFilter(decimal minPrice, decimal maxPrice)
    {
        var books = await _dbContext.Books
                                    .Where(b => b.Price >= minPrice && b.Price <= maxPrice)
                                    .ToListAsync();
        return books;
    }
}
