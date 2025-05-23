using ReadHaven.Application.Responses;

namespace ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;

public class CreateRatingReviewResponse : BaseResponse
{
    public CreateRatingReviewResponse() : base()
    {
    }

    public CreateRatingReviewDto RatingReview { get; set; } = default!;
}
