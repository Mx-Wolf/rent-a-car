using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Esx.Integration.Audit;

public interface IChangeTrackerHelper
{
    Dictionary<string, PropertyChange> GetChanges(PropertyValues original, PropertyValues current);
}
