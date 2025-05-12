using ReadHaven.Domain.Common;

namespace ReadHaven.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public Guid OrderId { get; set; } = Guid.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
