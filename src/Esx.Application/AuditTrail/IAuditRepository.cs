
using Esx.Domain.AuditTrailEntity;

namespace Esx.Application.AuditTrail;

public interface IAuditRepository
{
    void Add(IEnumerable<AuditTrailBase> records);
}

public interface IPropertyAuditConfig
{
    string GetLabel(string propertyName);
    string? GetFormat(string propertyName);
}
