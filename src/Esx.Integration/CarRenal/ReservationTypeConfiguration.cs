using Esx.Domain.CarEntity;
using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.CarRenal;

public class ReservationTypeConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new ReservationId(value)
            )
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CarId)
            .HasConversion(
                id => id.Value,
                value => new CarId(value)
            );

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(e => e.CustomerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
