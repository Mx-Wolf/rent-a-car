using System.Text.Json;

using Esx.Domain.AuditTrailEntity;
using Esx.Integration.CarRenal;
using Esx.Integration.TypeConfiguration;

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

        services.AddDbContext<CarRentalDbContext>((o) =>
        {
            o.UseSqlServer(configuration.GetConnectionString("CarRentalDb"));
        });
        return services;
    }
}
