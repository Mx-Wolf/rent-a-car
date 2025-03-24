namespace Esx.Domain.AuditTrailEntity;
public sealed class AuditRecord { 
    public required string Category { get; init; }
    public required int ObjectId { get; init; }
    public required string ObjectName { get; init; }
    public required UserInfo CompletedBy { get; init; }
    public required DateTime DateCompleted { get; init; }
    public required ICollection<ChangeInfo> Changes { get; init; }
}

public class AuditTrial : EntityBase<AuditTrialId>
{

    public required AuditRecord Record { get; init; }

    public AuditTrial() : base(AuditTrialId.Empty)
    {

    }
}

public class AuditTrail<TExtra> : EntityBase<AuditTrialId> where TExtra : class
{
    public required AuditRecord Record { get; init; }
    public required TExtra Extra { get; init; }

    public AuditTrail() : base(AuditTrialId.Empty)
    {
        
    }
}
