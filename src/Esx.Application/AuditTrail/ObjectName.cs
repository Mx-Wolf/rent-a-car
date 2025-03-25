namespace Esx.Application.AuditTrail;

public record ObjectName (string Name, int ObjectId)
{
    public static readonly ObjectName Empty = new(string.Empty, 0);
}
