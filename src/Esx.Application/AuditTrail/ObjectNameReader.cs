
namespace Esx.Application.AuditTrail;

public class ObjectNameReader : IObjectNameReader
{
    public ObjectName ReadObjectName(object subject)
    {
        if (subject == null) return ObjectName.Empty;
        return subject is IObjectNameProvider onp
            ? onp.GetName()
            : PrepareFromMetaData(subject);
    }

    private ObjectName PrepareFromMetaData(object subject)
    {
        return new ObjectName(
            Name: subject.GetType().Name,
            ObjectId: 0
            );
    }
}
