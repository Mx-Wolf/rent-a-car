using System.Text.Json;

using Esx.Domain.AuditTrailEntity;
using Esx.Integration.TypeConfiguration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Esx.Integration.CarRenal;


public class CarRentalDbContext : DbContext
{
    private readonly JsonSerializerOptions jsonSerializerOptions;
    private readonly ValueConverter<ICollection<ChangeInfo>, string> converter;
    private readonly ValueComparer<ICollection<ChangeInfo>> comparer;
    public CarRentalDbContext(
        DbContextOptions<CarRentalDbContext> options,
        JsonSerializerOptions jsonSerializerOptions,
        ValueConverter<ICollection<ChangeInfo>, string> converter,
        ValueComparer<ICollection<ChangeInfo>> comparer) : base(options)
    {
        this.jsonSerializerOptions = jsonSerializerOptions;
        this.converter = converter;
        this.comparer = comparer;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var m = modelBuilder;
        //m.ApplyConfigurationsFromAssembly(typeof(AuditTrailTypeConfiguration).Assembly);
        m.ApplyConfiguration(new AuditTrailTypeConfiguration(jsonSerializerOptions, converter, comparer));
        m.ApplyConfiguration(new CarTypeConfiguration());
        m.ApplyConfiguration(new CustomerTypeConfiguration());
        m.ApplyConfiguration(new ReservationTypeConfiguration());

    }
}
