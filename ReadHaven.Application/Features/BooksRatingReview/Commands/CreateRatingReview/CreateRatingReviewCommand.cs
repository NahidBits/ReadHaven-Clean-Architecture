using MediatR;
using Microsoft.AspNetCore.Http;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;

public class CreateRatingReviewCommand : IRequest<CreateRatingReviewResponse>
{
    public string ReviewText { get; set; }
    public Rating Rating { get; set; }
    public Guid BookId { get; set; }
}
