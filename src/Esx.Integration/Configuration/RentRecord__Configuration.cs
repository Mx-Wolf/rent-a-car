using Esx.Domain;
using Esx.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.Configuration;

internal class RentRecord__Configuration : IEntityTypeConfiguration<RentRecord>
{
    public void Configure(EntityTypeBuilder<RentRecord> builder)
    {
        builder.ToTable("RentRecord");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
            a => a.Value,
            v => new RentRecordId(v))
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.AdditionalFees)
            .IsMoney();
        builder.Property(x => x.TotalCharges)
            .IsMoney();

        builder.Property(e => e.PickupLocation)
            .HasColumnName(nameof(RentRecord.PickupLocation));



        builder.Property(x => x.AdditionalFees)
            .HasColumnName(nameof(RentRecord.AdditionalFees));
        builder.Property(x => x.PaymentConfirmation)
            .HasColumnName(nameof(RentRecord.PaymentConfirmation));
        builder.Property(x => x.TotalCharges)
            .HasColumnName(nameof(RentRecord.TotalCharges));

    }
}