
using Esx.Application.AuditTrail;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Esx.Integration.Audit;

public class ChangeTrackerHelper : IChangeTrackerHelper
{
    private readonly IPropertyAuditConfig auditConfig;

    public ChangeTrackerHelper(IPropertyAuditConfig auditConfig)
    {
        this.auditConfig = auditConfig;
    }

    public Dictionary<string, PropertyChange> GetChanges(
        PropertyValues original,
        PropertyValues current
        )
    {
        return original.Properties
            .Where(property => original[property]?.ToString() != current[property]?.ToString())
            .ToDictionary(
                property => auditConfig.GetLabel(property.Name),
                property => new PropertyChange(
                    FormatValue(original[property], auditConfig.GetFormat(property.Name)),
                    FormatValue(current[property], auditConfig.GetFormat(property.Name))
                    )
            );
    }

    private static string FormatValue(object? value, string? format)
    {
        if (value == null) return string.Empty;

        if (!string.IsNullOrEmpty(format))
        {
            // Apply the format string if provided
            return string.Format(format, value);
        }

        // Fallback to the default string representation
        return value.ToString() ?? string.Empty;
    }
}
