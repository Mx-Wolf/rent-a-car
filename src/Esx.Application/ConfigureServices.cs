using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esx.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(ApplicationAssembly.Reference);
        
        return services;
    }
}
