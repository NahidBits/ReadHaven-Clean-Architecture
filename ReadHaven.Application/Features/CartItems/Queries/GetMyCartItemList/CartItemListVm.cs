namespace ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;

public class CartItemListVm
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
