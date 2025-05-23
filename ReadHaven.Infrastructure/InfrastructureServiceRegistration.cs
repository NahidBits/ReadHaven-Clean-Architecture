using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadHaven.Application.Common.Interfaces.Security;
using ReadHaven.Application.Contracts.Infrastructure;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Contracts.Services;
using ReadHaven.Application.Models.Authentication;
using ReadHaven.Infrastructure.Email;
using ReadHaven.Infrastructure.Otp;
using ReadHaven.Infrastructure.Security;
using ReadHaven.Infrastructure.Services;

namespace ReadHaven.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFileService, FileService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddMemoryCache();
        services.AddTransient<IOtpService, OtpService>();
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}
