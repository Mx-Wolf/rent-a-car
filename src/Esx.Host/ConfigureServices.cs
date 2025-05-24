using Esx.Application;
using Esx.Integration;

namespace Esx.Host;

public static class ConfigureServices
{
    public static IServiceCollection AddCustomServices(
        this IServiceCollection services,
        IWebHostEnvironment host,
        IConfiguration configuration)
    {

        services.AddApplicationServices(configuration);
        services.AddIntegrationServices(host.ContentRootPath, configuration);
        services.Scan(s =>
        {
            s.FromAssemblies(ApplicationAssembly.Reference)
            .AddClasses()
            .AsMatchingInterface()
            .WithScopedLifetime();
        });
        return services;
    }
}
