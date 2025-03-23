using Esx.Domain.CarEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.CarRenal;
public class CarTypeConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new CarId(value))
            .IsRequired();

    }
}
