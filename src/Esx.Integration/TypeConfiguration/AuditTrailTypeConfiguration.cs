using System.Text.Json;

using Esx.Domain.AuditTrailEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Esx.Integration.TypeConfiguration;

public class AuditTrailTypeConfiguration : IEntityTypeConfiguration<AuditTrial>
{
    private readonly JsonSerializerOptions jsonSerializerOptions;
    private readonly ValueConverter<ICollection<ChangeInfo>, string> converter;
    private readonly ValueComparer<ICollection<ChangeInfo>> comparer;

    public AuditTrailTypeConfiguration(
        JsonSerializerOptions jsonSerializerOptions,
        ValueConverter<ICollection<ChangeInfo>, string> converter,
        ValueComparer<ICollection<ChangeInfo>> comparer)
    {
        this.jsonSerializerOptions = jsonSerializerOptions;
        this.converter = converter;
        this.comparer = comparer;
    }

    public void Configure(EntityTypeBuilder<AuditTrial> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasConversion(
              id => id.Value,
              value => new AuditTrialId(value)
            )
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(e => e.Category)
            .HasMaxLength(128)
            .IsRequired();

        builder.Property(e => e.ObjectId)
            .IsRequired(true);

        builder.Property(e => e.ObjectName)
            .HasMaxLength(int.MaxValue)
            .IsRequired();

        builder.OwnsOne(e => e.CompletedBy, o =>
        {
            o.Property(p => p.UserName)
            .HasColumnName("CompletedByUserName")
            .HasMaxLength(256)
            .IsRequired();

            o.Property(p => p.Email)
            .HasColumnName("CompletedByEmail")
            .HasMaxLength(256)
            .IsRequired();
        });


        builder.Property(e => e.DateCompleted)
            .IsRequired();
       
       
        builder.Property(e => e.Changes)
            .HasConversion(
                converter,
                comparer
            )
            .IsRequired();
    }
}
