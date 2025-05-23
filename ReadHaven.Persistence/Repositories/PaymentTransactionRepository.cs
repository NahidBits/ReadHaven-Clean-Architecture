

using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Persistence.Repositories;

public class PaymentTransactionRepository : BaseRepository<PaymentTransaction>, IPaymentTransactionRepository
{
    public PaymentTransactionRepository(ReadHavenDbContext dbContext) : base(dbContext)
    {
    }

}
