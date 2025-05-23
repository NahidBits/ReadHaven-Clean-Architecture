using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IBookRatingReviewRepository : IAsyncRepository<BookRatingReview>
{
}
