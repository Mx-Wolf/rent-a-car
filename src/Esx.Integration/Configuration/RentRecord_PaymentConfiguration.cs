using Esx.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.Configuration;

internal class RentRecord_PaymentConfiguration: IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
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
            .IsMoney()
            .HasColumnName(nameof(RentRecord.AdditionalFees));

        builder.Property(x => x.PaymentConfirmation)
            .HasColumnName(nameof(RentRecord.PaymentConfirmation));

        builder.Property(x => x.TotalCharges)
            .IsMoney()
            .HasColumnName(nameof(RentRecord.TotalCharges));

        builder.HasOne<RentRecord>().WithOne().HasForeignKey<Payment>(e => e.Id);

    }
}