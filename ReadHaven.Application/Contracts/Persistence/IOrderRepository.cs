using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{

}
