using Esx.Domain.Repositories;
using Esx.Integration.Repositories;
using Esx.Integration.Seeding;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esx.Integration;
public static class ConfigureServices
{
    public static IServiceCollection AddIntegrationServices(
        this IServiceCollection services,
        string contentRoot,
        IConfiguration configuration)
    {
        services.AddDbContext<MemoryDbContext>((sp,options) => {
            var connectionString = sp
            .GetRequiredService<IConfiguration>()
            .GetConnectionString("Memory");
            options.UseSqlServer(
                    connectionString, 
                    s => s.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
            options.EnableDetailedErrors(true);
            options.EnableSensitiveDataLogging(true);
            options.UseAsyncSeeding(MemoryDbContextSeed.Create(
                contentRoot,
                configuration["seeding"] ?? throw new InvalidDataException()));
            options.UseSeeding(MemoryDbContextSeed.CreateSeeder(
                contentRoot,
                configuration["seeding"] ?? throw new InvalidDataException()));
        });
        services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}

