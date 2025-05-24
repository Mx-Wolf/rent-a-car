using Esx.Domain.Repositories;
using Esx.Integration.Repositories;
using Esx.Integration.Seeding;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esx.Integration;
public static class ConfitureServices
{
    public static IServiceCollection AddIntegrationServices(
        this IServiceCollection services,
        string contentRoot,
        IConfiguration configuration)
    {
        services.AddDbContext<MemoryDbContext>(options => {
            options.UseInMemoryDatabase("Demo");
            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
            options.UseAsyncSeeding(MemoryDbContextSeed.Create(
                contentRoot,
                configuration["seeding"] ?? throw new InvalidDataException()));
        });
        services.AddHostedService<SeedingService>();
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        return services;
    }
}

