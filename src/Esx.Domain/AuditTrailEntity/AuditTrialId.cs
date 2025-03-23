namespace Esx.Domain.AuditTrailEntity;

[StronglyTypedId]
public readonly partial struct AuditTrialId :
    IEntityKey,
    IComparisonOperators<AuditTrialId, AuditTrialId, bool>,
    IEqualityOperators<AuditTrialId, AuditTrialId, bool>
{ }
