using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Persistence.Repositories;

namespace ReadHaven.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReadHavenDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ReadHavenConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookRatingReviewRepository, BookRatingReviewRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IOtpRepository, OtpRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();
        return services;
    }
}
