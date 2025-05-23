using MediatR;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;

public class CreateRatingReviewDto
{
    public Guid Id { get; set; }
    public string ReviewText { get; set; }
    public Rating Rating { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
