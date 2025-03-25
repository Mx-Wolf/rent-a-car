using System.Text.Json;

using Esx.Application;
using Esx.Application.AuditTrail;
using Esx.Application.ReservationUse;
using Esx.Domain;
using Esx.Integration.Audit;
using Esx.Integration.CarRenal;

namespace Esx.Host;

public static class ConfigureServices
{
    public static IServiceCollection ConfitureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddControllers();

        services.AddScoped<IReservationRequestHandler, ReservationRequestHandler>();

        //From Integration
        services.AddSingleton(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IEntityRepository<,>), typeof(GenericEntityRepository<,>));
        services.AddScoped<IAuditRepository, AuditRepository>();
        services.AddScoped<IAuditTrailCollector, AuditTrailCollector>();
        services.AddSingleton<IChangeTrackerHelper, ChangeTrackerHelper>();
        services.AddScoped<AuditTrailInterceptor>();
        services.AddCarRentalDbContext(configuration);
        return services;
    }
}
