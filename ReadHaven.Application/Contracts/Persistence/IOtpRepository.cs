using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Contracts.Persistence;

public interface IOtpRepository : IAsyncRepository<OtpRequest>
{
    Task<OtpRequest?> GetValidOtpAsync(string email);
}
