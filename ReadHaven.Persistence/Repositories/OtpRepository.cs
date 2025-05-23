using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Persistence.Repositories;

public class OtpRepository : BaseRepository<OtpRequest>, IOtpRepository
{
    public OtpRepository(ReadHavenDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<OtpRequest?> GetValidOtpAsync(string email)
    {
        return await _dbContext.OtpRequests
            .Where(o => o.Email == email && o.IsValidated && o.ExpiryTime > DateTime.UtcNow)
            .OrderByDescending(o => o.CreatedAt)
            .FirstOrDefaultAsync();
    }
}
