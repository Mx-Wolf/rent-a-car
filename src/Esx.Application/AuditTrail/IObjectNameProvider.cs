namespace Esx.Application.AuditTrail;

public interface IObjectNameProvider 
{
    ObjectName GetName();
}
public interface IObjectCatetoryProvider
{
    string GetCatetory();
}
public interface IObjectIdProvider
{
    int GetObjectId();
}