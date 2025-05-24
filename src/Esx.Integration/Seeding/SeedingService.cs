using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Esx.Integration.Seeding;
public class SeedingService(IServiceProvider serviceProvider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = serviceProvider.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MemoryDbContext>();
        await db.Database.EnsureCreatedAsync(stoppingToken);
    }
}
