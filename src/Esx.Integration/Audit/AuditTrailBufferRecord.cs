using Esx.Domain;

using Microsoft.EntityFrameworkCore;

namespace Esx.Integration.Audit;

public class AuditTrailBufferRecord
{
    public required EntityState State { get; init; }
    public required EntityBase? Entity { get; init; }
    public required IReadOnlyDictionary<string, PropertyChange> ChangesByField { get; init; }
}
