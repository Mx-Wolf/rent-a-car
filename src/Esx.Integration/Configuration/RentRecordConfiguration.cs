using Esx.Domain;
using Esx.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esx.Integration.Configuration;
internal class RentRecordConfiguration : IEntityTypeConfiguration<RentRecord>
{
    public void Configure(EntityTypeBuilder<RentRecord> builder)
    {
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
    }
}

public static class PropertyConfigureExtensions
{
    public static PropertyBuilder<T> IsMoney<T>(this PropertyBuilder<T> builder)
        => builder.HasPrecision(15, 2);
}