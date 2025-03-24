namespace Esx.Domain.AuditTrailEntity;

public abstract class AuditTrailBase : EntityBase<AuditTrialId>
{
    protected AuditTrailBase() : base(AuditTrialId.Empty)
    { }
}
