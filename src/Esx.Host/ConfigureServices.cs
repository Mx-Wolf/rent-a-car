using Esx.Application;
using Esx.Application.ReservationUse;
using Esx.Controllers;
using Esx.Domain;
using Esx.Integration.CarRenal;

namespace Esx.Host;

public static class ConfigureServices
{
    public static IServiceCollection ConfitureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();
        services.AddControllers();//.AddApplicationPart(typeof(ReservationsController).Assembly);

        services.AddScoped<IReservationRequestHandler, ReservationRequestHandler>();

        //From Integration
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IEntityRepository<,>), typeof(GenericEntityRepository<,>));
        services.AddCarRentalDbContext(configuration);
        return services;
    }
}
