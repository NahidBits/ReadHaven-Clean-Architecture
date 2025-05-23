using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IPaymentTransactionRepository : IAsyncRepository<PaymentTransaction>
{
}
