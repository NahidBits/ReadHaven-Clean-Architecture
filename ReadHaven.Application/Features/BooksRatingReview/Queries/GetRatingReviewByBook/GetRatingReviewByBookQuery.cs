using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReadHaven.Application.Features.BooksRatingReview.Queries.GetRatingReviewByBook;

public class GetRatingReviewByBookQuery : IRequest<List<RatingReviewVm>>
{
    public Guid BookId { get; set; }
}
