namespace Esx.Domain.AuditTrailEntity;

public record ChangeInfo(
    string Action,
    string Field,
    string OldValue,
    string NewValue
    );