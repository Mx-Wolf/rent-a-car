namespace Esx.Application.AuditTrail;

public interface IObjectNameReader
{
    ObjectName ReadObjectName(object subject);
}
public interface ICatetoryReader
{
    string GetCatetoryName(object subject);
}