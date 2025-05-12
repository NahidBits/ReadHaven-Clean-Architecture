using ReadHaven.Domain.Common;

namespace ReadHaven.Domain.Entities;
public class Wishlist : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public bool IsLoved { get; set; } = false;
}
