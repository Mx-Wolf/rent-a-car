namespace Esx.Domain.AuditTrailEntity;
public class AuditTrial : EntityBase<AuditTrialId>
{

    public required string Category { get; init; }
    public required int ObjectId { get; init; }
    public required string ObjectName { get; init; }
    public required UserInfo CompletedBy { get; init; }
    public required DateTime DateCompleted { get; init; }
    public required ICollection<ChangeInfo> Changes { get; init; }

    public AuditTrial() : base(AuditTrialId.Empty)
    {

    }
}
