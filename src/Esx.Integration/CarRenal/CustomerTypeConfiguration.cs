using Esx.Domain.CustomerEntity;
using Esx.Domain.ReservationEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.CarRenal;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new CustomerId(value))
            .IsRequired();

        builder.OwnsOne(e => e.PaymentInfo,
            pib =>
            {
                pib.Property(p => p.PreferedMethod).HasColumnName("PaymentMethod");
                pib.Property(p => p.Verified).HasColumnName("PaymentVerified");

            });
        builder
            .HasMany<Reservation>("Reservations")
            .WithOne("Customer")
            .HasForeignKey(e => e.CustomerId)
            .IsRequired();
    }
}
