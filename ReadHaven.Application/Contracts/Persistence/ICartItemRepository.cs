using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface ICartItemRepository : IAsyncRepository<CartItem>
{
    Task<CartItem?> GetByUserAndBookAsync(Guid userId, Guid bookId);
    Task<List<CartItem>> GetByUserIdAsync(Guid userId);
    Task<bool> ExistsAsync(Guid userId);
    Task<List<CartItem>>  GetSoftDeletedByOrderIdAsync(Guid orderId);
}
