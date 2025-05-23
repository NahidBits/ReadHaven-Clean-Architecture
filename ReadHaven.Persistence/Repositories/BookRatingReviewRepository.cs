using Microsoft.EntityFrameworkCore;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Persistence.Repositories;

public class BookRatingReviewRepository : BaseRepository<BookRatingReview>, IBookRatingReviewRepository
{
    public BookRatingReviewRepository(ReadHavenDbContext dbContext) : base(dbContext)
    {
    }
}
