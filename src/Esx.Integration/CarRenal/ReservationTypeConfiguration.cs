using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.CarRenal;

public class ReservationTypeConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new ReservationId(value)
            )
            .IsRequired();

        builder.Property<Customer>("Customer");
    }
}
