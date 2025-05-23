using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadHaven.Domain.Enums;

namespace ReadHaven.Application.Features.BooksRatingReview.Queries.GetRatingReviewByBook;

public class RatingReviewVm
{
    public string ReviewText { get; set; }
    public Rating Rating { get; set; }
    public Guid UserId { get; set; }
}
