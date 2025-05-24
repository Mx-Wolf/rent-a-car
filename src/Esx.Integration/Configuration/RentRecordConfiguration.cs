using Esx.Domain;

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
            v => new RentRecordId(v));
    }
}
