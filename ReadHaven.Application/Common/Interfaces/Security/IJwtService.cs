using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReadHaven.Application.Common.Interfaces.Security
{
    public interface IJwtService
    {
        string GenerateToken(string email, string tokenType = "auth", int durationMinutes = 30);
        ClaimsPrincipal? GetPrincipalFromToken(string token);
    }
}
