using Esx.Integration.CarRenal;

using Microsoft.EntityFrameworkCore;

namespace Esx.Host;

public static class DbContextExtensions
{
    public static IServiceCollection AddCarRentalDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CarRentalDbContext>(options => {
            options
            .UseSqlServer(configuration.GetConnectionString("CarRentalDb"));
            /*options.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));*/
        });
        return services;
    }
}
