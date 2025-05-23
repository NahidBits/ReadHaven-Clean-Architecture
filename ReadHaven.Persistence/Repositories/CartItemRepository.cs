using Microsoft.EntityFrameworkCore;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Persistence.Repositories;

public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
{
    public CartItemRepository(ReadHavenDbContext dbContext) : base(dbContext)
    {
    }
    public async Task<CartItem?> GetByUserAndBookAsync(Guid userId, Guid bookId)
    {
        return await _dbContext.CartItems
            .FirstOrDefaultAsync(ci => ci.UserId == userId && ci.BookId == bookId);
    }
    public async Task<List<CartItem>> GetByUserIdAsync(Guid userId)
    {
        return await _dbContext.CartItems
            .Where(ci => ci.UserId == userId && !ci.IsDeleted)
            .ToListAsync();
    }

    public async Task<List<CartItem>> GetSoftDeletedByOrderIdAsync(Guid orderId)
    {
        return await _dbContext.CartItems
            .IgnoreQueryFilters() 
            .Where(ci => ci.OrderId == orderId && ci.IsDeleted)
            .ToListAsync();
    }

    public async Task<bool> ExistsAsync(Guid userId)
    {
        return await _dbContext.CartItems
            .AnyAsync(ci => ci.UserId == userId);
    }       
}
