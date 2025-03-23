using Esx.Domain.CarEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.CarRenal;
public class CarTypeConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(e=>e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new CarId(value))
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Pice)
            .HasPrecision(19, 4);

    }
}
