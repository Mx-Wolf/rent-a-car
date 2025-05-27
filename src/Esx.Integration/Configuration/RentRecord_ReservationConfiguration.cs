using Esx.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.Configuration;

internal class RentRecord_ReservationConfiguration: IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("RentRecord");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(
                a => a.Value,
                v => new RentRecordId(v))
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(x => x.PickupLocation)
            .HasColumnName(nameof(RentRecord.PickupLocation));

        builder.HasOne<RentRecord>().WithOne().HasForeignKey<Reservation>(e => e.Id);

    }
}