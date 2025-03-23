using Esx.Domain.CustomerEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.TypeConfiguration;

public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => new CustomerId(value))
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.OwnsOne(e => e.Name, nb =>
        {
            nb.Property(p => p.FirstName).HasColumnName("FirstName");
            nb.Property(p => p.LastName).HasColumnName("LastName");
        });

        builder.Property(e => e.DriverLicense).IsRequired();

        builder.OwnsOne(e => e.PaymentInfo,
            pib =>
            {
                pib.Property(p => p.PreferedMethod).HasColumnName("PaymentMethod");
                pib.Property(p => p.Verified).HasColumnName("PaymentVerified");

            });

    }
}
