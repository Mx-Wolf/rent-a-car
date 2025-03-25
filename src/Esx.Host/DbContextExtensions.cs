using System.Text.Json;

using Esx.Domain.AuditTrailEntity;
using Esx.Integration.Audit;
using Esx.Integration.CarRenal;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Esx.Host;

public static class DbContextExtensions
{
    public static IServiceCollection AddCarRentalDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton((sp) =>
        {
            var jsonSerializerOptions = sp.GetRequiredService<JsonSerializerOptions>();

            return new ValueConverter<ICollection<ChangeInfo>, string>(changes => JsonSerializer.Serialize(changes, jsonSerializerOptions),
                json => JsonSerializer.Deserialize<List<ChangeInfo>>(json, jsonSerializerOptions) ?? new List<ChangeInfo>());
        });

        services.AddSingleton(
            new ValueComparer<ICollection<ChangeInfo>>(
            (
                ICollection<ChangeInfo>? l,
                ICollection<ChangeInfo>? r
            ) => Enumerable.SequenceEqual(l ?? Array.Empty<ChangeInfo>(), r ?? Array.Empty<ChangeInfo>()),

            (ICollection<ChangeInfo> o) => o.Aggregate(0, (a, b) => a ^ b.GetHashCode())));

        services.AddDbContext<CarRentalDbContext>((sp, o) =>
        {
            o.UseSqlServer(configuration.GetConnectionString("CarRentalDb"));
            o.AddInterceptors(
                sp.GetRequiredService<AuditTrailInterceptor>()
                );
        });
        return services;
    }
}
