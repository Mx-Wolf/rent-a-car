using Esx.Domain.AuditTrailEntity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Esx.Integration.TypeConfiguration;
public class AuditTrailDocumentExtraTypeConfiguration : IEntityTypeConfiguration<AuditTrail<DocumentExtra>>
{
    private readonly ValueConverter<ICollection<ChangeInfo>, string> converter;
    private readonly ValueComparer<ICollection<ChangeInfo>> comparer;

    public AuditTrailDocumentExtraTypeConfiguration(
        ValueConverter<ICollection<ChangeInfo>, string> converter,
        ValueComparer<ICollection<ChangeInfo>> comparer)
    {
        this.converter = converter;
        this.comparer = comparer;
    }

    public void Configure(EntityTypeBuilder<AuditTrail<DocumentExtra>> builder)
    {
        var b = builder;

        b.ToTable("DocumentAuditTrail");
        b.HasKey(e => e.Id);

        b.Property(e => e.Id)
            .HasConversion(
              id => id.Value,
              value => new AuditTrialId(value)
            )
            .ValueGeneratedOnAdd()
            .IsRequired();

        b.OwnsOne(e => e.Record, pb =>
        {
            pb.Property(e => e.Category)
           .HasMaxLength(128)
           .IsRequired();

            pb.Property(e => e.ObjectId)
                .IsRequired(true);

            pb.Property(e => e.ObjectName)
                .HasMaxLength(int.MaxValue)
                .IsRequired();

            pb.OwnsOne(e => e.CompletedBy, o =>
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


            pb.Property(e => e.DateCompleted)
                .IsRequired();


            pb.Property(e => e.Changes)
                .HasConversion(
                    converter,
                    comparer
                )
                .IsRequired();
        });

        b.OwnsOne(e => e.Extra, pb =>
        {
            pb.Property(p => p.Document)
            .HasColumnName("DocumentId");
        });


    }
}
