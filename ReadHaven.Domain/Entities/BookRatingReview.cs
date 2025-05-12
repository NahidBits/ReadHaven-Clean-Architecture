
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Enums;   

namespace ReadHaven.Domain.Entities;

public class BookRatingReview : BaseEntity
{
    public string ReviewText { get; set; }
    public Rating Rating { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
}
